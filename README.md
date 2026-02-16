# Todo List API

## Project Overview

This is a simple Todo List project built with **ASP.NET Core Web API** and **MongoDB**.  
It supports CRUD operations (Create, Read, Update, Delete) with additional features like toggling completion status.

---

## Features

- Create new todo items
- Get all todo items
- Get todo item by ID
- Update todo item (toggle complete/incomplete)
- Update todo item (rename item)
- Delete todo item by ID
- Delete completed items or delete all items

---

## Technologies Used

- ASP.NET Core 10 Web API
- MongoDB (NoSQL Database)
- C# Programming Language
- Postman (for API testing)

---

## Installation

## Clone the repository

```bash
git clone https://github.com/wynehtetaung/todo-_api_with_asp.net.git
cd todo-api
dotnet restore
dotnet run
```

---

## API Endpoints

### Get all todo

GET /api/todo

### Get todo by id

GEt /api/todo/{id}

### Create new todo

POST /api/todo
Content-Type: application/json
{ "item": "Buy milk" }

### Toggle todo (true ↔ false)

PATCH /api/todo/{id}

### Update todo

PUT /api/todo/{id}
Content-Type: application/json
{"item : "update item"}

### Delete todo by id

DELETE /api/todo/{id}

### Delete all todos

DELETE /api/todo?option=all
