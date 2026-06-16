using ConsultantRuleConstructor.Data;
using Microsoft.EntityFrameworkCore;
using ConsultantRuleConstructor.Entities;
using ConsultantRuleConstructor.Interfaces;
using ConsultantRuleConstructor;





using var context = new AppDbContext();

IUnitOfWork unitOfWork = new UnitOfWork(context);

IRuleConstructionService service =
    new RuleConstructionService(unitOfWork);


while (true)
{
    Console.WriteLine();
    Console.WriteLine("1. Создать правило");
    Console.WriteLine("2. Получить все правила");
    Console.WriteLine("3. Получить правило по Id");
    Console.WriteLine("0. Выход");

    var choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
            CreateRule(service);
            break;

        case "2":
            ShowAllRules(service);
            break;

        case "3":
            ShowRuleById(service);
            break;

        case "0":
            return;
    }
}

static void CreateRule(
    IRuleConstructionService service)
{

    // Вводим название правила, этого в диаграмме последовательности нет, можем сделать Id названием
    Console.Write("Введите название правила: ");
    string ruleName = Console.ReadLine() ?? "";
    var builder = new RuleBuilder().SetName(ruleName);



    // Вводим документ
    Document document;
    while (true)
    {
        document = new Document();
        Console.Write("Название документа(пустую строку, чтобы закончить): ");
        var documentName = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(documentName)) break;
        document.Name = documentName;  
        
        builder.addTargetDocument(document);
        
    }




    // Вводим профиль
    Console.Write("Статус пользователя(true, false или пустую строку: ");
    var status = Console.ReadLine() ?? "";
    
        
    var profile = new Profile
    {
        resettlementStatus = status == "true",
        requiredDocuments = builder._rule.Documents
    };
    builder = new RuleBuilder().AddProfile(profile);


    Console.WriteLine("Добавим еще руководства и организации к ним и правило будет создано");

    // Руководство
    while (true)
    {
        Guide guide = new Guide();

        // Если сообщение или текст отказа пустые, то завершаем и то, и другое не записывая ничего
        Console.WriteLine("Введите текст руководства");
        string messageText = Console.ReadLine() ?? "" ?? "";
        if (string.IsNullOrWhiteSpace(messageText)) break;

        Console.WriteLine("Введите текст отказа");
        string refuseText = Console.ReadLine() ?? "";                
        if (string.IsNullOrWhiteSpace(refuseText)) break;


        guide.Message = messageText;
        guide.Refuse = refuseText;


        // Организации
        List<Organization> organizations = [];
        while (true)
        {
            Console.Write("Введите название организации, где можно получить документ(или пустую строку, чтобы закончить): ");
            string name = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(name)) break;

            Console.Write("Введите адрес организации, где можно получить документ(или пустую строку, чтобы закончить): ");
            string address = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(address)) break;

            guide.Organizations.Add(new Organization
            {
                Name = name,
                Address = address
            });
        }



        builder = new RuleBuilder().addGuide(guide);

    }

    Rule rule = builder.Build();

    var id = service.addRule(rule);

    Console.WriteLine();
    Console.WriteLine($"Создано правило #{id}");
}

static void ShowAllRules(
    IRuleConstructionService service)
{
    var rules = service.GetAllRules();

    foreach (var rule in rules)
    {
        Console.WriteLine();
        Console.WriteLine(
            $"{rule.Id} - {rule.Name}");
    }
}

static void ShowRuleById(
    IRuleConstructionService service)
{
    Console.Write("Введите Id: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int id))
    {
        return;
    }

    var rule = service.GetById(id);

    if (rule == null)
    {
        Console.WriteLine("Правило не найдено");
        return;
    }
    Console.WriteLine($"Id: {rule.Id}");
    Console.WriteLine($"Название {rule.Name}");
    
    foreach(Document documents in rule.Documents)
    {

        Console.WriteLine($"Документы: {documents.Name}");
    }
        
    foreach(var guide in rule.Guids)
    {
        Console.WriteLine($"Описание правила: {guide.Message}");
        Console.WriteLine($"Описание отказа правила {guide.Refuse}");

        foreach (var organization in guide.Organizations)
        {
            Console.WriteLine($"\t Организация: {organization.Name}");
            Console.WriteLine($"\t Адрес: {organization.Address}");
        }
    }
    

}