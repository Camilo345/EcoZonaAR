using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;


public class enviarEmail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enviarCorreo(string filepath)
    {

        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("juancamilobola354@gmail.com");
        mail.To.Add("jcamilob3456@gmail.com");
        mail.Subject = "Fotos ZonaEco";
        mail.Body = "Prueba envio Correo";

        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment(filepath);
        mail.Attachments.Add(attachment);

        SmtpServer.Port = 587;
        SmtpServer.Credentials = new System.Net.NetworkCredential("juancamilobola354@gmail.com", "ldzzsvqditlppxak");
        SmtpServer.EnableSsl = true;

        SmtpServer.Send(mail);
    }
}
