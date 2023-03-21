using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Scrapping.CLI;
internal class App
{
    internal static async Task Run()
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        HttpClient client = new();

        // Call asynchronous network methods in a try/catch block to handle exceptions.
        try
        {
            //using HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            string responseBody = await client.GetStringAsync("http://www.contoso.com/");

            Console.WriteLine(responseBody);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
    }

    internal static void SeleniumDriver()
    {
        IWebDriver driver = new EdgeDriver();
        driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

        var title = driver.Title;

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

        var textBox = driver.FindElement(By.Name("my-text"));
        var submitButton = driver.FindElement(By.TagName("button"));

        textBox.SendKeys("Selenium");
        submitButton.Click();

        var message = driver.FindElement(By.Id("message"));

        var value = message.Text;

        Console.WriteLine($"Received! {value}");

        driver.Quit();

        Console.WriteLine(title);
    }
}
