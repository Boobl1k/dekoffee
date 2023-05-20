using Main.Application.Models;
using Main.Tools;
using Microsoft.EntityFrameworkCore;

namespace Main.Infrastructure.Data.Seed;

internal static class ProductSeed
{
    public const string AmericanoId = "CFBD118C-51E4-4A29-9DDD-58777D85E0A3";
    public const string CappuccinoId = "71755A93-7C3F-4137-BB5D-11C8B4539556";
    public const string LatteId = "8BA706AB-387F-41D4-9FA0-9F419BC0793E";
    public const string DefaultImageUrl = "https://i.imgur.com/fE10Rf0.jpg";
    public static void AddSeedProducts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(GetSeedProducts());
    }

    private static IEnumerable<object> GetSeedProducts()
    {
        //эспрессо
        yield return new
        {
            Id = "CA4F0C3E-67C0-429B-824F-D13A1AD1B4FE".ToGuid(),
            Title = "Эспрессо",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/9a/Espresso_and_napolitains.jpg",
            Price = 1000m,
            Description =
                "Самый популярный вид кофе в Европе, готовится в кофемашине, требует специального, очень ровного помола. Готовят из смеси арабики и робусты, часто из специально собранных купажей. Для хорошо приготовленного кофе характерна плотная, устойчивая пенка светло-кремового цвета. Пьют после еды, в несколько глотков, так, чтобы кофе не успел остыть. Пенку перемешивают с жидкостью, для придания равномерного вкуса всему напитку. Стандартный объем порции – 35 грамм.",
            Net = 35.0,
            Gross = 45.0,
            Country = "Норвегия",
            EnergyValue = 9.0,
            IsBlocked = false
        };
        yield return new
        {
            Id = "2C8F1066-892A-4737-9901-286A2127C846".ToGuid(),
            Title = "Доппио",
            ImageUrl = "https://kofella.net/images/stories/vseokofe/kofe-doppio-dvoynoy-espresso.jpg",
            Price = 1700m,
            Description = "Двойной эспрессо. Пьют горячим, иногда с тростниковым сахаром.",
            Net = 70.0,
            Gross = 80.0,
            Country = "Федеративные Штаты Микронезии",
            EnergyValue = 9.0,
            IsBlocked = false
        };
        yield return new
        {
            Id = "7348C294-82C0-4BFB-9072-7AFC8BEC3D82".ToGuid(),
            Title = "Кофе по-венски",
            ImageUrl = "https://static-sl.insales.ru/files/1/3224/17050776/original/16250378047.jpg?1625037804",
            Price = 2200m,
            Description =
                "Эспрессо, в который добавлена порция хорошо взбитых сливок. Сверху они посыпаются ароматными специями и шоколадом. Подают в чашках среднего или большого объема. Пьют в любое время дня и ночи, обычно с десертами или выпечкой. В процессе употребления такой кофе не принято перемешивать.",
            Net = 100.0,
            Gross = 110.0,
            Country = "Венесуэла",
            EnergyValue = 6.0,
            IsBlocked = false
        };
        yield return new
        {
            Id = "6EB85D1A-1839-4F07-92E3-8C7D9A281F09".ToGuid(),
            Title = "Романо",
            ImageUrl = "https://latte.ru/wa-data/public/site/img/kofa.png",
            Price = 2000m,
            Description =
                "Эспрессо по-римски. Готовят, как обычный эспрессо, подают с долькой лимона или длинной закрученной полоской лимонной цедры. Пьют после еды, без десертов и сладостей.",
            Net = 80.0,
            Gross = 90.0,
            Country = "Мальта",
            EnergyValue = 7.5,
            IsBlocked = false
        };
        yield return new
        {
            Id = "EBE0FA86-E594-468D-B375-3A281A705F06".ToGuid(),
            Title = "Ристретто",
            ImageUrl = "https://coffeepedia.ru/wp-content/uploads/2015/04/salek-na-espresso-a-ristretto-cesky-porcelan-50-ml-kava.jpg",
            Price = 700m,
            Description =
                "Имеет очень маленький объем и низкое содержание кофеина. Для приготовления берется 5-7 грамм кофе на 25 грамм воды. Очень распространен в Италии, у нас популярность напитка гораздо ниже. Подают ристретто после обеда или ужина, без сахара, с бокалом холодной воды. Сначала делают несколько глотков воды, затем быстро выпивают ристретто. Вода нужна, чтобы очистить вкусовые рецепторы после приема пищи, и предотвратить обезвоживание после крепкого кофе.",
            Net = 30.0,
            Gross = 40.0,
            Country = "Суринам",
            EnergyValue = 4.0,
            IsBlocked = false
        };
        yield return new
        {
            Id = "403D26F4-5F81-4682-B073-06A507BF9944".ToGuid(),
            Title = "Лунго",
            ImageUrl = "https://coffeepedia.ru/wp-content/uploads/2015/04/D6550501-6.jpg",
            Price = 800m,
            Description =
                "Переходный вариант между эспрессо и американо. Можно сказать, американо по-итальянски. Объем эспрессо увеличивается в два раза за счет воды. Пьют после еды. Обычно такой рецепт выбирают те, кто хочет снизить порцию кофеина, но не готов отказаться от него совсем.",
            Net = 40.0,
            Gross = 50.0,
            Country = "Экваториальная Гвинея",
            EnergyValue = 4.0,
            IsBlocked = false
        };
        yield return new
        {
            Id = AmericanoId.ToGuid(),
            Title = "Американо",
            ImageUrl = "https://coffe-spb.ru/img/cms/americano.jpg",
            Price = 3300m,
            Description =
                "Эспрессо, разбавленный водой. После приготовления основной порции в 30 мл, бариста прогоняет дополнительно еще 90-120 грамм воды, увеличивая объем без повышения крепости напитка. Пьют после еды или в перерывах между ней, с добавлением сахара, молока, сливок. Американо зачастую сопровождается десертами или печеньем.",
            Net = 130.0,
            Gross = 140.0,
            Country = "Гаити",
            EnergyValue = 9.5,
            IsBlocked = false
        };
        yield return new
        {
            Id = "5EF11CED-6193-4116-9DE2-0811F2340602".ToGuid(),
            Title = "Макиато",
            ImageUrl = "https://img.povar.ru/main-micro/09/2b/82/ac/makiato-773259.JPG",
            Price = 2900m,
            Description =
                "В переводе с итальянского означает «пятнистый». Название получил за внешний вид. Это обычный эспрессо, на который сверху кладется ложка молочной пены. Пьют после приема пищи, не смешивая пену и кофе.",
            Net = 100.0,
            Gross = 110.0,
            Country = "Ямайка",
            EnergyValue = 19.0,
            IsBlocked = false
        };

        //молоко
        yield return new
        {
            Id = CappuccinoId.ToGuid(),
            Title = "Капучино",
            ImageUrl = "https://i-coffee.me/wp-content/uploads/2022/02/Coffee_Cappuccino_Cream_Cup_Saucer_525045_2048x1152-1024x576.jpg",
            Price = 3100m,
            Description =
                "Кофе с молоком, которое взбито в пышную пену, с нежной структурой. Сверху добавляет тертый шоколад, какао, корицу или сахарную пудру. Пьют капучино в перерывах между едой, в Италии – на родине рецепта, его употребляют лишь в первой половине дня, до 16 часов. Обычная порция – 150 грамм, оптимальная температура употребления – 60 градусов. Капучино часто сопровождают небольшими порциями десертов, печеньем, шоколадом.",
            Net = 150.0,
            Gross = 160.0,
            Country = "Германия",
            EnergyValue = 90.0,
            IsBlocked = false
        };
        yield return new
        {
            Id = LatteId.ToGuid(),
            Title = "Латте",
            ImageUrl = "https://coffeepedia.ru/wp-content/uploads/2013/01/coffee.jpg",
            Price = 3000m,
            Description =
                "Готовят из одной части эспрессо и двух частей молока со взбитой пеной. Дополняют вкус разнообразными сиропами, из которых самые популярные – карамельный, шоколадный и клубничный. Употребляют в любое время, как коктейль, подают в высоких бокалах с соломинками",
            Net = 150.0,
            Gross = 160.0,
            Country = "Гренландия",
            EnergyValue = 200.0,
            IsBlocked = false
        };
        yield return new
        {
            Id = "202A5477-CE2D-4824-966A-AFDC6422915A".ToGuid(),
            Title = "Латте макиато",
            ImageUrl = "https://static.1000.menu/img/content-v2/7f/14/52510/kofe-latte-makiato-v-domashnix-usloviyax_1611233825_8_max.jpg",
            Price = 3150m,
            Description =
                "Напиток, в котором эспрессо, молоко и пена из взбитых сливок или молока лежат слоями. Употребляют в перерывах между едой. Подают напиток в высоком бокале, пьют, не перемешивая слои, используя соломинку.",
            Net = 150.0,
            Gross = 160.0,
            Country = "Вануату",
            EnergyValue = 29.0,
            IsBlocked = false
        };
    }
}