# MusicStore-BackendControllers

Контроллеры REST API для сервиса - музыкального магазина, работа над которым проводилась в рамках учебной практики.

## Обзор

Этот репозиторий содержит контроллеры для управления данными музыкального магазина. 
Они предоставляют RESTful API для взаимодействия с базой данных, используя модели и CRUD операции из репозитория `MusicStore`.

## Технологии

* **[Фреймворк]**:  ASP.NET Core
* **[Язык программирования]**:  C#
* **[Фреймворк для создания контроллеров и REST API в ASP.NET Core]**:  Microsoft.AspNetCore.Mvc
* **[Библиотека для работы с базами данных]**:  LinqToDB
* **[Формат обмена данными для сериализации и десериализации]**:  JSON

## Примеры

**Использование API:**

*   **`Get` (Получить все товары):**
    ```
    GET /api/Product/GetProducts
    ```
*   **`Post` (Создать новый товар):**
    ```
    POST /api/Product/NewProduct
    ```
    **Тело запроса:**
    ```json
    {
      "subcategory": 1, 
      "title": "Название товара",
      "description": "Описание товара",
      "price": 10.99,
      "unitsInCart": 0,
      "unitsInStock": 10,
      "rating": 4.5,
      "picture": "image.jpg"
    }
    ```
*   **`Put` (Обновить информацию о товаре):**
    ```
    PUT /api/Product/UpdateProduct/1
    ```
    **Тело запроса:**
    ```json
    {
      "subcategory": 1, 
      "title": "Обновленное название товара",
      "description": "Обновленное описание",
      "price": 12.99,
      "unitsInCart": 0,
      "unitsInStock": 10,
      "rating": 4.5,
      "picture": "image.jpg"
    }
    ```
*   **`Delete` (Удалить товар):**
    ```
    DELETE /api/Product/DeleteProduct/1 
    ```
*   **`GetProductsBySubcategory` (Получить товары по подкатегории):**
    ```
    GET /api/Product/GetProductsBySubcategory/1
    ```
*   **`GetProductById` (Получить товар по ID):**
    ```
    GET /api/Product/GetProductById/1
    ```
