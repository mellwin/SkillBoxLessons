using ConsoleApp1;

void PrintCustumers(List<Custumer> custumers)
{
    //Вывод содержимого таблицы
    if (custumers.Count == 0)
    {
        Console.WriteLine("Элементов нет");
        return;
    }
    foreach (var custumer in custumers)
    {
        Console.WriteLine(custumer.Name + " " + custumer.LastName + " " + custumer.PhoneNumber);
    }
};

async Task CreateNewCustumers()
{
    //Заполнение таблицы
    for (int i = 0; i < 10; i++)
    {
        await CustumerDBRepo.Insert(new Custumer(
                                            Guid.NewGuid(),
                                            "Фамилия_" + i,
                                            "Имя_" + i,
                                            "Отчество_" + i,
                                            "Номер_" + i,
                                            "Имейл_" + i
                                            ), "NewLOGIN", "SomePassword");
    }
}

async Task DeleteAllCustumers(List<Custumer> custumers)
{
    //Удаление содержимого таблицы
    foreach (var custumer in custumers)
    {
        CustumerDBRepo.Delete(custumer.Id, "NewLOGIN", "SomePassword");
    }
}

async Task UpdateCustumer(List<Custumer> custumers)
{
    //изменение клиента
    foreach (var custumer in custumers)
    {
        custumer.Name += "_1";
        await CustumerDBRepo.Update(custumer, "NewLOGIN", "SomePassword");
    }
}

void PrintProdutcs(List<Product> products)
{
    //Вывод содержимого таблицы
    if (products.Count == 0)
    {
        Console.WriteLine("Элементов нет");
        return;
    }
    foreach (var product in products)
    {
        Console.WriteLine(product.ProductName + " " + product.ProductCode + " " + product.Email);
    }
};

async Task CreateNewProdutcs()
{
    //Заполнение таблицы
    for (int i = 0; i < 10; i++)
    {
        await ProductDBRepo.Insert(new Product(
                                            Guid.NewGuid(),
                                            "Email_" + i,
                                            i,
                                            "ProductName_" + i
                                            ));
    }
}

async Task DeleteAllProdutcs(List<Product> products)
{
    //Удаление содержимого таблицы
    foreach (var product in products)
    {
        await ProductDBRepo.Delete(product.Id);
    }
}

async Task UpdateProdutcs(List<Product> products)
{
    //изменение клиента
    foreach (var product in products)
    {
        product.ProductName += "_1";
        await ProductDBRepo.Update(product);
    }
}


Console.WriteLine("Начало");

#region MSSQLDB
//Console.WriteLine("Добавление");
////создаю клиентов в бд
//await CreateNewCustumers();
//var custumers = await CustumerDBRepo.SelectAllCustumers();
//PrintCustumers(custumers);

//Console.WriteLine();

//Console.WriteLine("Изменение");
////изменяю клиентов в бд
//await UpdateCustumer(custumers);


////выбираю измененных клиентов из бд
//custumers = await CustumerDBRepo.SelectAllCustumers();
//PrintCustumers(custumers);


//Console.WriteLine("Удаление");
////Удаляю клиентов из бд
//await DeleteAllCustumers(custumers);
//custumers = await CustumerDBRepo.SelectAllCustumers();
//PrintCustumers(custumers);
#endregion

#region MSAccessDB
Console.WriteLine("Добавление");
////создаю клиентов в бд
//await CreateNewProdutcs();
//var products = await ProductDBRepo.SelectAllProducts();
//PrintProdutcs(products);

//Console.WriteLine();

//Console.WriteLine("Изменение");
////изменяю клиентов в бд
//await UpdateProdutcs(products);


////выбираю измененных клиентов из бд
//products = await ProductDBRepo.SelectAllProducts();
//PrintProdutcs(products);


//Console.WriteLine("Удаление");
////Удаляю клиентов из бд
//await DeleteAllProdutcs(products);
//products = await ProductDBRepo.SelectAllProducts();
//PrintProdutcs(products);
#endregion


Console.WriteLine("Конец");