// See https://aka.ms/new-console-template for more information
using Csharp_Basic_Logger;

string? message = Console.ReadLine();
Logger.WriteLog(message == null ? "No hay mensaje":message);