namespace TestingEmialling.Utils
{
    public interface IMailSender
    {
        void SendPlainTextGmail(string reciepientEmail, string recipientName);
        void SendHtmlGmail(string reciepientEmail, string recipientName);
        void SendHtmlWithAttachmentGmail(string reciepientEmail, string recipientName);

        void SendPlainTextSendGrid(string reciepientEmail, string recipientName);
        void SendHtmlSendGrid(string reciepientEmail, string recipientName);
        void SendHtmlWithAttachmentSendGrid(string reciepientEmail, string recipientName);
        void SendSendGridBulk(List<string> reciepientEmail);

    }
}
