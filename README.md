

# Calculator App

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0.html)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/en-us/)
[![Build Status](https://dev.azure.com/zavalik/codetraining/_apis/build/status%2FCI%20for%20Main%20Branch?branchName=main)](https://dev.azure.com/zavalik/codetraining/_build/latest?definitionId=1&branchName=main)
---

## 📖 Overview

**Calculator App** is a simple calculator application designed to showcase modern development practices including Clean Architecture, Unit Testing, CI/CD automation, and best coding standards using .NET.

This project serves both as a learning tool and a demonstration of high-quality code organization and delivery workflows.

---

## ✨ Features

- Basic calculator operations (add, subtract, multiply, divide)
- Clean Architecture structure
- Full Unit Test coverage
- Continuous Integration with GitHub Actions
- Follows best practices for .NET development
- Extensible for new features

---

## 🚀 Technologies

- [.NET 8.0](https://dotnet.microsoft.com/en-us/)
- xUnit and Shouldly for testing
- GitHub Actions for CI/CD
- Docker support (optional, if you add it later)

---

## ⚡ Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Git

### Running Locally
```bash
# Clone the repository
git clone https://github.com/rzavalik/codetraining.git
cd codetraining

# Build and run the application
dotnet build
dotnet run --project Calculator.UI
```

### Running Tests
```bash
# Execute unit tests
dotnet test
```

---

## 📂 Project Structure

```
src/
 └── Calculator.UI/          # Console UI for the calculator
 └── Calculator.API/          # Web API version (if implemented)
 └── Calculator.Domain/       # Core domain entities and logic
 └── Calculator.Application/  # Application logic and services
 └── Calculator.Tests/        # Unit tests
```

---

## 🤝 Contributing

We welcome contributions!

Please read our [CONTRIBUTING.md](./CONTRIBUTING.md) to learn how to get started.

---

## 📜 License

This project is licensed under the [GPL-3.0-or-later License](LICENSE).

---

## 🙌 Acknowledgments

- Inspired by clean architecture principles and best practices from the .NET community.
