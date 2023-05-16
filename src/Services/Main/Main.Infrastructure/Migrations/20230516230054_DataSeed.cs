using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Main.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Addresses");

            migrationBuilder.CreateTable(
                name: "AddressUser",
                columns: table => new
                {
                    AddressesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressUser", x => new { x.AddressesId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AddressUser_Addresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Apartment", "City", "Commentary", "Floor", "House", "Section", "Street" },
                values: new object[,]
                {
                    { new Guid("328d54c1-bf3e-417b-9c16-1e3963f3e7a4"), "1304", "Казань", null, 13, "35", 1, "Кремлевская" },
                    { new Guid("a372bb6b-2e44-4cf9-8a3c-bdbee21b3472"), "65", "Казань", null, 3, "69", 5, "Баева" },
                    { new Guid("f0ca1801-3f08-4659-8151-db84f2ee90b1"), "555555", "Казань", null, 55, "1337", 55, "Дениса Жукова" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("340126fb-e9c4-4857-9033-4a1e8af859b0"), null, "EXECUTOR_ROLE", "EXECUTOR_ROLE" },
                    { new Guid("697f3429-c044-46de-aabd-1b8f801a9464"), null, "ADMIN_ROLE", "ADMIN_ROLE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsBlocked", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0c3a4ac7-6fa2-4aad-a576-48ef57b1c999"), 0, null, "mansur@ema.il", true, false, false, true, null, "MANSUR@EMA.IL", "МАНСУР", "AQAAAAIAAYagAAAAENmUGtwOY7Ut9EUiAUxQyDMKbUrImirmDpv18CwWGO++XSp19PwN65tTRi0DfLiw3Q==", null, false, "18D6AB4E-F06A-4458-B24F-33DCC663BAC9", false, "Мансур" },
                    { new Guid("1799c9f1-e377-45fe-8858-d909d0c2f7a7"), 0, null, "adel@dekoff.ee", true, false, false, true, null, "ADEL@DEFOFF.EE", "БАРИСТА_АДЕЛЬ", "AQAAAAIAAYagAAAAEN9vIszn3vMDBijPE09ncS4sIfSz3/QJVQ64CtX//yV2kEO4O9zaHcw/GcJqGxmKHA==", null, false, "18D6AB4E-F06A-4458-B24F-33DCC663BAC9", false, "Бариста_Адель" },
                    { new Guid("780c9e97-6564-4a35-8195-9544ba50d904"), 0, null, "damir@ema.il", true, false, false, true, null, "DAMIR@EMA.IL", "ДАМИР", "AQAAAAIAAYagAAAAEEEOVIjCLuRoF3iESCH5PTC3eADekDi26kEcCHkzH0z61UvFg6oCDNCuyO7ppzJlFg==", null, false, "18D6AB4E-F06A-4458-B24F-33DCC663BAC9", false, "Дамир" },
                    { new Guid("a969812b-4fc3-4ffc-b739-2a467117f64e"), 0, null, "courier.dmitry@dekoff.ee", true, false, false, true, null, "COURIER.DMITRY@DEFOFF.EE", "КУРЬЕР_ДМИТРИЙ", "AQAAAAIAAYagAAAAEFP61C1SSl6cxkWDLo/6AuUA3YF/J0ENRCbdtoiRt4arfm1gGY3mCzvcd9PQQF896g==", null, false, "18D6AB4E-F06A-4458-B24F-33DCC663BAC9", false, "Курьер_Дмитрий" },
                    { new Guid("b1f872ed-1a8b-4d71-8694-e9273287f8ec"), 0, null, "courier.ruslan@dekoff.ee", true, false, false, true, null, "COURIER.RUSLAN@DEFOFF.EE", "КУРЬЕР_РУСЛАН", "AQAAAAIAAYagAAAAEGJtq/sjFcy7hNQZrxk4afWyTMSLgtPM4F4S0fVgfJvRFs52aTHLWmM+HPamnp8B1A==", null, false, "18D6AB4E-F06A-4458-B24F-33DCC663BAC9", false, "Курьер_Руслан" },
                    { new Guid("e58a4734-d89c-48eb-a65d-e0e192bdda7c"), 0, null, "admin@dekoff.ee", true, false, false, true, null, "ADMIN@DEFOFF.EE", "АДМИН", "AQAAAAIAAYagAAAAEL2uqcJoPLAhCgVbiS7eSJP7k3KP+mKYyMYphy7qEhISToFUOp8TwA8E6dG1PjtqqQ==", null, false, "18D6AB4E-F06A-4458-B24F-33DCC663BAC9", false, "Админ" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Country", "Description", "EnergyValue", "Gross", "IsBlocked", "Net", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("202a5477-ce2d-4824-966a-afdc6422915a"), "Вануату", "Напиток, в котором эспрессо, молоко и пена из взбитых сливок или молока лежат слоями. Употребляют в перерывах между едой. Подают напиток в высоком бокале, пьют, не перемешивая слои, используя соломинку.", 29.0, 160.0, false, 150.0, 3150m, "Латте макиато" },
                    { new Guid("2c8f1066-892a-4737-9901-286a2127c846"), "Федеративные Штаты Микронезии", "Двойной эспрессо. Пьют горячим, иногда с тростниковым сахаром.", 9.0, 80.0, false, 70.0, 1700m, "Доппио" },
                    { new Guid("403d26f4-5f81-4682-b073-06a507bf9944"), "Экваториальная Гвинея", "Переходный вариант между эспрессо и американо. Можно сказать, американо по-итальянски. Объем эспрессо увеличивается в два раза за счет воды. Пьют после еды. Обычно такой рецепт выбирают те, кто хочет снизить порцию кофеина, но не готов отказаться от него совсем.", 4.0, 50.0, false, 40.0, 800m, "Лунго" },
                    { new Guid("5ef11ced-6193-4116-9de2-0811f2340602"), "Ямайка", "В переводе с итальянского означает «пятнистый». Название получил за внешний вид. Это обычный эспрессо, на который сверху кладется ложка молочной пены. Пьют после приема пищи, не смешивая пену и кофе.", 19.0, 110.0, false, 100.0, 2900m, "Макиато" },
                    { new Guid("6eb85d1a-1839-4f07-92e3-8c7d9a281f09"), "Мальта", "Эспрессо по-римски. Готовят, как обычный эспрессо, подают с долькой лимона или длинной закрученной полоской лимонной цедры. Пьют после еды, без десертов и сладостей.", 7.5, 90.0, false, 80.0, 2000m, "Романо" },
                    { new Guid("71755a93-7c3f-4137-bb5d-11c8b4539556"), "Германия", "Кофе с молоком, которое взбито в пышную пену, с нежной структурой. Сверху добавляет тертый шоколад, какао, корицу или сахарную пудру. Пьют капучино в перерывах между едой, в Италии – на родине рецепта, его употребляют лишь в первой половине дня, до 16 часов. Обычная порция – 150 грамм, оптимальная температура употребления – 60 градусов. Капучино часто сопровождают небольшими порциями десертов, печеньем, шоколадом.", 90.0, 160.0, false, 150.0, 3100m, "Капучино" },
                    { new Guid("7348c294-82c0-4bfb-9072-7afc8bec3d82"), "Венесуэла", "Эспрессо, в который добавлена порция хорошо взбитых сливок. Сверху они посыпаются ароматными специями и шоколадом. Подают в чашках среднего или большого объема. Пьют в любое время дня и ночи, обычно с десертами или выпечкой. В процессе употребления такой кофе не принято перемешивать.", 6.0, 110.0, false, 100.0, 2200m, "Кофе по-венски" },
                    { new Guid("8ba706ab-387f-41d4-9fa0-9f419bc0793e"), "Гренландия", "Готовят из одной части эспрессо и двух частей молока со взбитой пеной. Дополняют вкус разнообразными сиропами, из которых самые популярные – карамельный, шоколадный и клубничный. Употребляют в любое время, как коктейль, подают в высоких бокалах с соломинками", 200.0, 160.0, false, 150.0, 3000m, "Латте" },
                    { new Guid("ca4f0c3e-67c0-429b-824f-d13a1ad1b4fe"), "Норвегия", "Самый популярный вид кофе в Европе, готовится в кофемашине, требует специального, очень ровного помола. Готовят из смеси арабики и робусты, часто из специально собранных купажей. Для хорошо приготовленного кофе характерна плотная, устойчивая пенка светло-кремового цвета. Пьют после еды, в несколько глотков, так, чтобы кофе не успел остыть. Пенку перемешивают с жидкостью, для придания равномерного вкуса всему напитку. Стандартный объем порции – 35 грамм.", 9.0, 45.0, false, 35.0, 1000m, "Эспрессо" },
                    { new Guid("cfbd118c-51e4-4a29-9ddd-58777d85e0a3"), "Гаити", "Эспрессо, разбавленный водой. После приготовления основной порции в 30 мл, бариста прогоняет дополнительно еще 90-120 грамм воды, увеличивая объем без повышения крепости напитка. Пьют после еды или в перерывах между ней, с добавлением сахара, молока, сливок. Американо зачастую сопровождается десертами или печеньем.", 9.5, 140.0, false, 130.0, 3300m, "Американо" },
                    { new Guid("ebe0fa86-e594-468d-b375-3a281a705f06"), "Суринам", "Имеет очень маленький объем и низкое содержание кофеина. Для приготовления берется 5-7 грамм кофе на 25 грамм воды. Очень распространен в Италии, у нас популярность напитка гораздо ниже. Подают ристретто после обеда или ужина, без сахара, с бокалом холодной воды. Сначала делают несколько глотков воды, затем быстро выпивают ристретто. Вода нужна, чтобы очистить вкусовые рецепторы после приема пищи, и предотвратить обезвоживание после крепкого кофе.", 4.0, 40.0, false, 30.0, 700m, "Ристретто" }
                });

            migrationBuilder.InsertData(
                table: "AddressUser",
                columns: new[] { "AddressesId", "UserId" },
                values: new object[,]
                {
                    { new Guid("328d54c1-bf3e-417b-9c16-1e3963f3e7a4"), new Guid("0c3a4ac7-6fa2-4aad-a576-48ef57b1c999") },
                    { new Guid("a372bb6b-2e44-4cf9-8a3c-bdbee21b3472"), new Guid("780c9e97-6564-4a35-8195-9544ba50d904") },
                    { new Guid("f0ca1801-3f08-4659-8151-db84f2ee90b1"), new Guid("780c9e97-6564-4a35-8195-9544ba50d904") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("340126fb-e9c4-4857-9033-4a1e8af859b0"), new Guid("1799c9f1-e377-45fe-8858-d909d0c2f7a7") },
                    { new Guid("340126fb-e9c4-4857-9033-4a1e8af859b0"), new Guid("a969812b-4fc3-4ffc-b739-2a467117f64e") },
                    { new Guid("340126fb-e9c4-4857-9033-4a1e8af859b0"), new Guid("b1f872ed-1a8b-4d71-8694-e9273287f8ec") },
                    { new Guid("697f3429-c044-46de-aabd-1b8f801a9464"), new Guid("e58a4734-d89c-48eb-a65d-e0e192bdda7c") }
                });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "CartUserId", "Id", "Count", "ProductId" },
                values: new object[,]
                {
                    { new Guid("0c3a4ac7-6fa2-4aad-a576-48ef57b1c999"), 1, 2, new Guid("71755a93-7c3f-4137-bb5d-11c8b4539556") },
                    { new Guid("0c3a4ac7-6fa2-4aad-a576-48ef57b1c999"), 2, 1, new Guid("8ba706ab-387f-41d4-9fa0-9f419bc0793e") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressId", "CompleteTime", "DeadlineTime", "ExecutorId", "LastUpdateTime", "LowerSelectedTime", "Status", "TotalSum", "UpperSelectedTime", "UserId" },
                values: new object[,]
                {
                    { new Guid("6b75f65b-52c5-402f-a446-a6c8ef14af80"), new Guid("a372bb6b-2e44-4cf9-8a3c-bdbee21b3472"), null, new DateTime(2023, 5, 16, 16, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 5, 12, 13, 10, 2, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 6, 10m, new DateTime(2023, 5, 16, 16, 0, 0, 0, DateTimeKind.Unspecified), new Guid("780c9e97-6564-4a35-8195-9544ba50d904") },
                    { new Guid("964d25df-c2ac-4511-b43f-6588394afd52"), new Guid("f0ca1801-3f08-4659-8151-db84f2ee90b1"), null, new DateTime(2024, 10, 16, 16, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b1f872ed-1a8b-4d71-8694-e9273287f8ec"), new DateTime(2023, 5, 12, 18, 10, 2, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 1000000m, new DateTime(2024, 5, 16, 16, 0, 0, 0, DateTimeKind.Unspecified), new Guid("780c9e97-6564-4a35-8195-9544ba50d904") },
                    { new Guid("f1bc39f8-0434-4c23-ab66-0db72ac81b14"), new Guid("328d54c1-bf3e-417b-9c16-1e3963f3e7a4"), null, new DateTime(2024, 5, 16, 16, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 5, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 8600m, new DateTime(2024, 5, 16, 16, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0c3a4ac7-6fa2-4aad-a576-48ef57b1c999") }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "Id", "OrderId", "Count", "ProductId" },
                values: new object[,]
                {
                    { 2, new Guid("6b75f65b-52c5-402f-a446-a6c8ef14af80"), 10000, new Guid("8ba706ab-387f-41d4-9fa0-9f419bc0793e") },
                    { 4, new Guid("964d25df-c2ac-4511-b43f-6588394afd52"), 1, new Guid("71755a93-7c3f-4137-bb5d-11c8b4539556") },
                    { 1, new Guid("f1bc39f8-0434-4c23-ab66-0db72ac81b14"), 3, new Guid("cfbd118c-51e4-4a29-9ddd-58777d85e0a3") },
                    { 3, new Guid("f1bc39f8-0434-4c23-ab66-0db72ac81b14"), 1, new Guid("8ba706ab-387f-41d4-9fa0-9f419bc0793e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressUser_UserId",
                table: "AddressUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressUser");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("340126fb-e9c4-4857-9033-4a1e8af859b0"), new Guid("1799c9f1-e377-45fe-8858-d909d0c2f7a7") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("340126fb-e9c4-4857-9033-4a1e8af859b0"), new Guid("a969812b-4fc3-4ffc-b739-2a467117f64e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("340126fb-e9c4-4857-9033-4a1e8af859b0"), new Guid("b1f872ed-1a8b-4d71-8694-e9273287f8ec") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("697f3429-c044-46de-aabd-1b8f801a9464"), new Guid("e58a4734-d89c-48eb-a65d-e0e192bdda7c") });

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumns: new[] { "CartUserId", "Id" },
                keyValues: new object[] { new Guid("0c3a4ac7-6fa2-4aad-a576-48ef57b1c999"), 1 });

            migrationBuilder.DeleteData(
                table: "CartProduct",
                keyColumns: new[] { "CartUserId", "Id" },
                keyValues: new object[] { new Guid("0c3a4ac7-6fa2-4aad-a576-48ef57b1c999"), 2 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "Id", "OrderId" },
                keyValues: new object[] { 2, new Guid("6b75f65b-52c5-402f-a446-a6c8ef14af80") });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "Id", "OrderId" },
                keyValues: new object[] { 4, new Guid("964d25df-c2ac-4511-b43f-6588394afd52") });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "Id", "OrderId" },
                keyValues: new object[] { 1, new Guid("f1bc39f8-0434-4c23-ab66-0db72ac81b14") });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "Id", "OrderId" },
                keyValues: new object[] { 3, new Guid("f1bc39f8-0434-4c23-ab66-0db72ac81b14") });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("202a5477-ce2d-4824-966a-afdc6422915a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2c8f1066-892a-4737-9901-286a2127c846"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("403d26f4-5f81-4682-b073-06a507bf9944"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5ef11ced-6193-4116-9de2-0811f2340602"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6eb85d1a-1839-4f07-92e3-8c7d9a281f09"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7348c294-82c0-4bfb-9072-7afc8bec3d82"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ca4f0c3e-67c0-429b-824f-d13a1ad1b4fe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ebe0fa86-e594-468d-b375-3a281a705f06"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("340126fb-e9c4-4857-9033-4a1e8af859b0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("697f3429-c044-46de-aabd-1b8f801a9464"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1799c9f1-e377-45fe-8858-d909d0c2f7a7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a969812b-4fc3-4ffc-b739-2a467117f64e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e58a4734-d89c-48eb-a65d-e0e192bdda7c"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("6b75f65b-52c5-402f-a446-a6c8ef14af80"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("964d25df-c2ac-4511-b43f-6588394afd52"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f1bc39f8-0434-4c23-ab66-0db72ac81b14"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("71755a93-7c3f-4137-bb5d-11c8b4539556"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ba706ab-387f-41d4-9fa0-9f419bc0793e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cfbd118c-51e4-4a29-9ddd-58777d85e0a3"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("328d54c1-bf3e-417b-9c16-1e3963f3e7a4"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("a372bb6b-2e44-4cf9-8a3c-bdbee21b3472"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("f0ca1801-3f08-4659-8151-db84f2ee90b1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c3a4ac7-6fa2-4aad-a576-48ef57b1c999"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("780c9e97-6564-4a35-8195-9544ba50d904"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1f872ed-1a8b-4d71-8694-e9273287f8ec"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
