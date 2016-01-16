using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsStore.Domain.Abstract;
using ElectronicsStore.Domain.Entities;
using System.Net.Mail;
using System.Net;

namespace ElectronicsStore.Domain.Concrete {
    public class EmailSettings {

        // Use a real smtp server if this to be used
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "electronicsstore@example.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;

        // May need to change these values if you want a file copy of email on local machine.
        public bool WriteAsFile = true;
        public string FileLocation = @"C:\Projects\ElectronicsStore\ElectronicsStoreEmails";
    }
    
    public class EmailOrderProcessor :IOrderProcessor {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings) {
            emailSettings = settings;
        }
        
        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient()) {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials  = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile) 
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                
                StringBuilder body = new StringBuilder().AppendLine("A new order has been submitted")
                                                        .AppendLine("---")
                                                        .AppendLine("Items:");
                
                foreach (var line in cart.Lines) {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity, line.Product.Name, subtotal);
                }
                
                body.AppendFormat("Total order value: {0:c}", cart.CalculateTotalValue()).AppendLine("---")
                                                                                       .AppendLine("Ship to:")
                                                                                       .AppendLine(shippingInfo.Name)
                                                                                       .AppendLine(shippingInfo.Line1)
                                                                                       .AppendLine(shippingInfo.Line2 ?? "")
                                                                                       .AppendLine(shippingInfo.Line3 ?? "")
                                                                                       .AppendLine(shippingInfo.Town)
                                                                                       .AppendLine(shippingInfo.County ?? "")
                                                                                       .AppendLine(shippingInfo.Country)
                                                                                       .AppendLine(shippingInfo.Postcode)
                                                                                       .AppendLine("---")
                                                                                       .AppendFormat("Gift wrap: {0}",
                                                                                       shippingInfo.GiftWrap ? "Yes" : "No");
                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress, // From
                                  emailSettings.MailToAddress, // To
                                  "New order submitted!", // Subject
                                  body.ToString()); // Body
                
                if (emailSettings.WriteAsFile) {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }
                
                smtpClient.Send(mailMessage);
            }
        }
    }
}