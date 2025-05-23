﻿namespace projectQuotes.Infrastructure.EmailServer;

public class EmailRequest
{
    public required string Subject { get; set; }
    public required string FromName { get; set; }
    public required string To { get; set; }
    public required string ToName { get; set; }
    public required string Html { get; set; }
    public required string PlainText { get; set; }
}