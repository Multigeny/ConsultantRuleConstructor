using ConsultantRuleConstructor.Data;
using Microsoft.EntityFrameworkCore;
using ConsultantRuleConstructor.Entities;
using ConsultantRuleConstructor.Interfaces;
using ConsultantRuleConstructor;



using var context = new AppDbContext();

//IUnitOfWork unitOfWork = new UnitOfWork(context);

IRuleConstructionService service =
    new RuleConstructionService(context);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Выберете действие:");
    Console.WriteLine("1 - Создать правило");
    Console.WriteLine("2 - Получить все правила");
    Console.WriteLine("3 - Получить правило по Id");
    Console.WriteLine("0 - Выход");
    Console.Write("Выбор: ");
    var choice = Console.ReadLine();

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
    // ============================== Правило ==============================
    var data = new RuleDto();

    Console.WriteLine("=========== Создание правила ===========");

    Console.Write("Название: ");
    data.Name = Console.ReadLine();

    Console.Write("Целевой документ: ");
    data.TargetDocument = new DocumentDto() { Name = Console.ReadLine() };

    // ============================== Руководство ==============================
    var guide = new GuideDto();
    Console.Write("Текст руководства: ");
    guide.Message = Console.ReadLine();

    Console.Write("Текст руководства (отказ): ");
    guide.Refuse = Console.ReadLine();

    var doOgranizationsAdd = true;
    var ogranizationNum = 1;
    while (doOgranizationsAdd)
    {
        Console.WriteLine("Выберете действие:");
        Console.WriteLine("1 - Добавить организацию");
        Console.WriteLine("0 - Закончить");
        Console.Write("Выбор: ");
        var ogranizationEventChoice = Console.ReadLine();
        switch (ogranizationEventChoice)
        {
            case "0":
                doOgranizationsAdd = false;
                break;
            case "1":
                Console.WriteLine("Организация " + ogranizationNum + ":");
                var organization = new OrganizationDto();
                Console.Write("Наименование: ");
                organization.Name = Console.ReadLine();
                Console.Write("Адрес: ");
                organization.Address = Console.ReadLine();
                guide.Organizations.Add(organization);
                ogranizationNum++;
                break;
        }

    }
    data.Guide = guide;

    // ============================== Профили ==============================
    Console.WriteLine("=========== Создание профилей правила ===========");
    var doProfileCreating = true;
    var profileNum = 1;
    while (doProfileCreating)
    {
        var profile = new ProfileDto();

        Console.WriteLine("Выберете действие:");
        Console.WriteLine("1 - Добавить профиль");
        Console.WriteLine("0 - Закончить");
        Console.Write("Выбор: ");
        var profileEventChoice = Console.ReadLine();
        switch (profileEventChoice)
        {
            case "0":
                doProfileCreating = false;
                break;
            case "1":
                Console.WriteLine("Профиль " + profileNum + ":");

                Console.WriteLine("Статут программы переселения соотечественников:");
                Console.WriteLine("1 - Не является участником");
                Console.WriteLine("2 - Является участником");
                Console.Write("Выбор: ");
                var resettlementProgramStatusChoice = Console.ReadLine();
                switch (resettlementProgramStatusChoice)
                {
                    case "1":
                        profile.ResettlementProgramStatus = false;
                        break;
                    case "2":
                        profile.ResettlementProgramStatus = true;
                        break;
                }

                // ============================== Требуемые документы ==============================
                var doRequiredDocumentsAdding = true;
                var documentNum = 1;
                while (doRequiredDocumentsAdding)
                {
                    Console.WriteLine("Выберете действие:");
                    Console.WriteLine("1 - Добавить требуемый документ");
                    Console.WriteLine("0 - Закончить");
                    Console.Write("Выбор: ");
                    var requiredDocumentEventChoice = Console.ReadLine();
                    switch (requiredDocumentEventChoice)
                    {
                        case "0":
                            doRequiredDocumentsAdding = false;
                            break;
                        case "1":
                            Console.WriteLine("Требуемый документ " + documentNum + ":");
                            Console.Write("Название документа: ");
                            profile.RequiredDocuments.Add(new DocumentDto() { Name = Console.ReadLine() });
                            documentNum++;
                            break;
                    }
                }

                data.Profiles.Add(profile);

                profileNum++;
                break;
        }
    }

    var id = service.CreateRule(data);

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
        Console.WriteLine("Ошибка!");
        return;
    }

    var rule = service.GetById(id);

    if (rule == null)
    {
        Console.WriteLine("Правило не найдено!");
        return;
    }

    Console.WriteLine($"Id: {rule.Id}");
    Console.WriteLine($"Название: {rule.Name}");
    Console.WriteLine($"Целевой документ: {rule.TargetDocument.Name}");
    Console.WriteLine("===== Руководство =====");
    Console.WriteLine($"- Текст: {rule.Guide.Message}");
    Console.WriteLine($"- Текст отказа: {rule.Guide.Refuse}");
    Console.WriteLine("- Организации:");
    foreach ((int index, OrganizationDto organization) in rule.Guide.Organizations.Index())
    {
        Console.WriteLine($"\t{index}) {organization.Name}. Адрес: {organization.Address}");
    }
    Console.WriteLine("===== Профили =====");
    foreach ((int index, ProfileDto profile) in rule.Profiles.Index())
    {
        Console.WriteLine($"{index}:");
        Console.WriteLine($"- Статус программы переселения соотечественников: {profile.ResettlementProgramStatus}");
        Console.WriteLine("- Требуемые документы:");
        foreach ((int docIndex, DocumentDto document) in profile.RequiredDocuments.Index())
        {
            Console.WriteLine($"\t{docIndex}) {document.Name}");
        }
    }
}