

# CSE2522 – Industrial Session on Software Testing and Validation

## Assignment 02 – Selenium Automation Testing

### Student Name: *[T.N.D.Gunawardana]*

### Registration Number: *[FC115561]*

### Module: CSE2522

### Tool: Selenium WebDriver with NUnit

### Language: C# (.NET)

---

## 📌 Overview

This project implements **automated UI test cases** for the **UI Testing Playground** website using **Selenium WebDriver**, **NUnit**, and the **Page Object Model (POM)** design pattern.

The automation covers the following functionalities:

* Text Input
* Sample App (Login)
* Client Side Delay
* Alerts (Alert, Confirm, Prompt)

All test cases are implemented according to the provided test case document.

---

## 🌐 Application Under Test

**URL:** [https://uitestingplayground.com/](https://uitestingplayground.com/)

---

## 🛠 Tools & Technologies Used

* **Language:** C#
* **Framework:** .NET
* **Automation Tool:** Selenium WebDriver
* **Testing Framework:** NUnit
* **Browser:** Google Chrome
* **Design Pattern:** Page Object Model (POM)
* **IDE:** Visual Studio

---

## 📂 Project Structure

```
CSE2522_Assignment02
│
├── Core
│   └── BaseTest.cs
│
├── Pages
│   ├── TextInputPage.cs
│   ├── SampleAppPage.cs
│   ├── ClientSideDelayPage.cs
│   └── AlertsPage.cs
│
├── Tests
│   ├── TextInputTests.cs
│   ├── SampleAppTests.cs
│   ├── ClientSideDelayTests.cs
│   └── AlertsTests.cs
│
└── README.md
```

---

## 🧪 Implemented Test Cases

### 🔹 Text Input

* TC001_1 – Verification of the Text Input page
* Verify textbox and button visibility
* Verify button text changes after input

### 🔹 Sample App

* TC002_1 – Verification of Sample App page
* TC002_2 – Successful login
* TC002_3 – Unsuccessful login

### 🔹 Client Side Delay

* TC003_1 – Verification of client-side delay functionality
* Validate loading indicator and result message

### 🔹 Alerts

* TC004_1 – Verification of Alerts page
* TC004_2 – Verification of Alert text
* TC004_3 – Verification of Confirm flow (Yes / No)
* TC004_4 – Verification of Prompt flow (Accept / Dismiss)

---

## ✅ Automation Approach

* **Page Object Model (POM)** is used to separate test logic from UI locators.
* **Explicit waits** are used to handle dynamic elements and delays.
* **Alerts are validated directly** using Selenium’s alert handling.
* Each test case uses **NUnit assertions** to verify expected outcomes.
* Common browser setup and teardown logic is handled in `BaseTest.cs`.

---

## ▶ How to Run the Tests

1. Open the solution in **Visual Studio**
2. Restore NuGet packages
3. Ensure **Google Chrome** is installed
4. Open **Test Explorer**
5. Click **Run All Tests**

---

## 📊 Test Results

* Total Tests: **9**
* Passed: **9**
* Failed: **0**

All test cases execute successfully.

---

## 📎 Notes

* The project follows best practices for Selenium automation.
* No hard-coded waits (`Thread.Sleep`) are used.
* The solution is compatible with the latest Chrome browser.

---

## 🔗 GitHub Repository

**Repository Link:** *[(https://github.com/navishd/stvassignment)]*

---

