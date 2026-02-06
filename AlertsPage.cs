public bool IsAlertPresent()
{
    try
    {
        _driver.SwitchTo().Alert();
        return true;
    }
    catch (NoAlertPresentException)
    {
        return false;
    }
}