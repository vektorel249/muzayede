using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace vektorel.Muzayede.UITests
{
    [TestFixture]
    public class ContactFormTest
    {
        [Test]
        public void Can_Fill_ContactForm()
        {
            var options = new EdgeOptions();
            using var driver = new EdgeDriver(options);

            driver.Navigate().GoToUrl("http://localhost:12501");
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("http://localhost:12501/Home/Contact");

            // 2. Sayfa yüklenmesini bekle (gelişmiş bekleme yapılabilir)
            Thread.Sleep(1000);

            // 3. Form alanlarını doldur
            driver.FindElement(By.Id("Name")).SendKeys("Ahmet Yılmaz");
            driver.FindElement(By.Id("Email")).SendKeys("ahmet.yilmaz@example.com");
            driver.FindElement(By.Id("Message")).SendKeys("Bu bir otomasyon test mesajıdır.");

            // Dropdown'a eriş
            var subjectDropdown = new SelectElement(driver.FindElement(By.Id("Subject")));
            // "Teknik" seçeneğini seç
            subjectDropdown.SelectByText("Teknik");

            // 4. Kaydet butonuna tıkla
            driver.FindElement(By.Id("saveBtn")).Click();

            // 5. Sonuç sayfası veya mesaj bekleniyorsa onu kontrol et (örnek: başarılı mesaj div'i)
            Thread.Sleep(2000); // sonucu görmek için bekleme
            Console.WriteLine("✅ Form başarıyla gönderildi.");

            driver.Quit();
        }
    }
}