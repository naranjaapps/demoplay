using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
class Program
{
    public static async Task Main()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();
        // Abre una nueva página
        var page = await context.NewPageAsync();
        // Navega a la página https://www.wikipedia.org/
        await page.GotoAsync("https://www.wikipedia.org/");
        // Da click en un input con el nombre search
        await page.ClickAsync("input[name=\"search\"]");
        // Escribe la palabra Testing al input con el nombre search
        await page.FillAsync("input[name=\"search\"]", "Testing");
        // Da clic en el texto Pruebas de Software
        await page.ClickAsync("text=Pruebas de software");
        // Assert.AreEqual("https://es.wikipedia.org/wiki/Pruebas_de_software", page.Url);
    }
}
