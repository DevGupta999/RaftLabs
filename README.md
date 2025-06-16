# RaftLabs .NET Developer Assignment

This repository contains a clean, modular .NET 8 class library for interacting with the ReqRes public API, as well as unit tests. It demonstrates good practices in API client design, error handling, and testability.

---
## How to build
dotnet build

## How to run unit tests
dotnet test

## Design highlights

 **Clean architecture**

* Interfaces for API client & service
* `HttpClient` used properly
* Ready for dependency injection


**Unit testing**

* Mocking API client
* Testing service logic independently

---

## How to push to GitHub

Initialize and add remote
git init
git remote add origin https://github.com/YourUsername/YourRepoName.git

Commit and push
git add .
git commit -m "Initial commit - RaftLabs assignment"
git branch -M main
git push -u origin main

If you see `non-fast-forward` error:

git pull origin main --rebase
git push -u origin main

