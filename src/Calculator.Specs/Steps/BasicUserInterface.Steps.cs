namespace Calculator.Specs.Steps
{
    using Calculator.Specs.Hooks;

    using OpenQA.Selenium;

    using Reqnroll;

    using Shouldly;

    using System.Linq;

    [Binding]
    public class BasicUserInterface
    {
        private IWebDriver Driver => WebDriverHooks.Driver!;

        [Given("the calculator web page is loaded")]
        public void GivenTheCalculatorWebPageIsLoaded()
        {
            Driver.Navigate().GoToUrl("https://localhost:7269/");
        }

        [Then("I should see buttons labeled \"0\" to \"9\"")]
        public void ThenIShouldSeeButtonsLabeled0To9()
        {
            for (int i = 0; i <= 9; i++)
            {
                var button = Driver
                    .FindElements(By.XPath($"//button[text()='{i}']"))
                    .FirstOrDefault();
                button.ShouldNotBeNull($"Expected to find button labeled '{i}', but it was missing.");
            }
        }

        [Then("I should see a button labeled (.*)")]
        public void ThenIShouldSeeAButtonLabeled(string operation)
        {
            var symbol = operation switch
            {
                "*" => "×",
                "/" => "÷",
                _ => operation
            };

            var button = Driver
                .FindElements(By.XPath($"//button[normalize-space(text())='{symbol}']"))
                .FirstOrDefault();
            button.ShouldNotBeNull($"Expected to find button labeled '{symbol}', but it was missing.");
        }

        [When("I click the mode toggle button")]
        [When("I click the mode toggle button again")]
        public void WhenIClickTheModeToggleButton()
        {
            var toggle = WebDriverHooks.Driver!.FindElement(By.Id("toggleMode"));
            toggle.Click();
        }

        [Then("the page should switch to light mode")]
        public void ThenThePageShouldSwitchToLightMode()
        {
            var body = WebDriverHooks.Driver!.FindElement(By.TagName("body"));
            body.GetAttribute("class")
                ?.ShouldContain("day-mode", customMessage: "Expected body to have class 'day-mode' after switching.");
        }

        [Then("the page should switch to dark mode")]
        public void ThenThePageShouldSwitchToDarkMode()
        {
            var body = WebDriverHooks.Driver!.FindElement(By.TagName("body"));
            body.GetAttribute("class")
                ?.ShouldNotContain("day-mode", customMessage: "Expected body to NOT have class 'day-mode' after switching.");
        }
    }
}
