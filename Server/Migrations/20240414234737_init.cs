using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProgrammingPro.Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImgName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<int>(type: "integer", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "text", nullable: true),
                    Answer1 = table.Column<string>(type: "text", nullable: true),
                    Answer2 = table.Column<string>(type: "text", nullable: true),
                    Answer3 = table.Column<string>(type: "text", nullable: true),
                    Answer4 = table.Column<string>(type: "text", nullable: true),
                    CorrectAnswer = table.Column<int>(type: "integer", nullable: true),
                    Points = table.Column<int>(type: "integer", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourses", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_UserCourses_Courses_UserId",
                        column: x => x.UserId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourses_Users_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Docs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocName = table.Column<string>(type: "text", nullable: true),
                    LessonId = table.Column<int>(type: "integer", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docs_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Docs_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Deadline = table.Column<DateOnly>(type: "date", nullable: true),
                    LessonId = table.Column<int>(type: "integer", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Homeworks_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Homeworks_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VideoName = table.Column<string>(type: "text", nullable: true),
                    LessonId = table.Column<int>(type: "integer", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Videos_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaterialName = table.Column<string>(type: "text", nullable: true),
                    HomeworkId = table.Column<int>(type: "integer", nullable: true),
                    LessonId = table.Column<int>(type: "integer", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Materials_Homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "Homeworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "ImgName", "Name" },
                values: new object[,]
                {
                    { 1, "C++ был разработан Бьёрном Страуструпом в подразделении Bell Labs компании AT&T в качестве дополнения к языку Cи. С++ добавил множество новых возможностей в язык Си. Его популярность была вызвана объектно-ориентированностью языка. Сейчас C++ широко используется для разработки программного обеспечения, являясь одним из самых популярных языков программирования. С его помощью создают операционные системы, разнообразные прикладные программы, драйверы устройств, игры и пр.", "", "C++" },
                    { 2, "C# — объектно-ориентированный язык программирования общего назначения. Разработан в 1998—2001 годах группой инженеров компании Microsoft под руководством Андерса Хейлсберга и Скотта Вильтаумота как язык разработки приложений для платформы Microsoft .NET Framework и .NET Core", "", "C#" },
                    { 3, "Java — строго типизированный объектно-ориентированный язык программирования общего назначения, разработанный компанией Sun Microsystems (в последующем приобретённой компанией Oracle). Разработка ведётся сообществом, организованным через Java Community Process; язык и основные реализующие его технологии распространяются по лицензии GPL. Права на торговую марку принадлежат корпорации Oracle.", "", "Java" },
                    { 4, "Python — высокоуровневый язык программирования общего назначения с динамической строгой типизацией и автоматическим управлением памятью, ориентированный на повышение производительности разработчика, читаемости кода и его качества, а также на обеспечение переносимости написанных на нём программ. Язык является полностью объектно-ориентированным в том плане, что всё является объектами.", "", "Python" },
                    { 5, "Ruby — динамический, рефлективный, интерпретируемый высокоуровневый язык программирования. Язык обладает независимой от операционной системы реализацией многопоточности, сильной динамической типизацией, сборщиком мусора и многими другими возможностями. По особенностям синтаксиса он близок к языкам Perl и Eiffel, по объектно-ориентированному подходу — к Smalltalk.", "", "Ruby" },
                    { 6, "PHP — скриптовый язык общего назначения, интенсивно применяемый для разработки веб-приложений. В настоящее время поддерживается подавляющим большинством хостинг-провайдеров и является одним из лидеров среди языков, применяющихся для создания динамических веб-сайтов.", "", "PHP" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "Text", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Прежде чем мы продолжим знакомство с переменными в C++, давайте узнаем, значениями какого типа мы можем заполнять созданные нами переменные.\r\n\r\nВот список стандартных типов данных:\r\n\r\nint - это целый тип, который может хранить в себе только целые числа.\r\nfloat - данный тип является неточным. Он позволяет хранить не только целую часть, но, в отличии от типа int, и дробную.\r\ndouble - данный тип нечем не отличается от float, кроме более высокой точности (позволяет хранить больше чисел после запятой).\r\nchar - в данный тип данных можно записывать отдельные символы (абсолютно любые).\r\nbool - хранит в себе значения логического типа: “правду” - true, либо “ложь” - false. О данном типе мы подробно поговорим в уроке о логических выражениях.\r\nТеперь когда мы вооружились знаниями о возможных типах данных, можем переходить непосредственно к созданию переменных на языке C++!", "Переменные" },
                    { 2, 1, "Заголовочный файл <cmath> стандартной библиотеки C++ определяет набор математических функций. которые можно использовать в программах. Перечислю наиболее распространенные:\r\n\r\nabs(arg): вычисляет абсолютное значение arg. В отличие от большинства функций , abs() возвращает целочисленный тип, если arg является целым числом.\r\n\r\nceil(arg): вычисляет ближайшее целое число, большее или равное arg, и возвращает его в виде числа с плавающей точкой. Например, выражение std::ceil(2.5) возвращает 3.0, а std::ceil(-2.5) - -2.0. (дробная часть округляется до единицы)\r\n\r\nfloor(arg): вычисляет ближайшее целое число, меньшее или равное arg, и возвращает его в виде числа с плавающей точкой. Например, выражение std::floor(2.5) возвращает 2.0, а std::floor(-2.5) - число -3.0. (дробная часть округляется до нуля)\r\n\r\nexp(arg): вычисляет выражение earg.\r\n\r\nlog(arg): вычисляет натуральный логарифм (по основанию e) числа arg.\r\n\r\nlog10(arg): вычисляет логарифм по основанию 10 от arg.\r\n\r\npow(arg1, arg2): вычисляет значение arg1, возведенное в степень arg2, то есть arg1arg2. Числа arg1 и arg2 могут быть целочисленными или с плавающей запятой. Так, результат std::pow(2, 3) равен 8.0, а std::pow(4, 0,5) равно 2,0.\r\n\r\nsqrt(arg): вычисляет квадратный корень из arg.\r\n\r\nround(arg), lround (arg) и llround (arg) округляют число до ближайщего целого. Разница между ними состоит в типа возвращаемого результата: round() возвращает число с плавающей точкой, lround (arg) - число long, а llround (arg) - long long.\r\n\r\nПоловинные значения округляются до нуля: std::lround(0.5) возвращает 1L, тогда как std::round(-1.5f) возвращает -2.0f.\r\n\r\nsin(arg): вычисляет синус угла, при этом arg представляет значение в радианах.\r\n\r\ncod(arg): вычисляет косинус угла.\r\n\r\ntan(arg): вычисляет тангенс угла.\r\n\r\nisinf(arg): возвращает true, если аргумент представляет +-бесконечность.\r\n\r\nisnan(arg): возвращает true, если аргумент представляет NaN.", "Математические операции" },
                    { 3, 1, "", "Логические операции" },
                    { 4, 1, "", "Массивы" },
                    { 5, 1, "", "Функции" },
                    { 6, 1, "", "Объекты" },
                    { 7, 2, "Для хранения данных в программе применяются переменные. Переменная представляет именнованную область памяти, в которой хранится значение определенного типа. Переменная имеет тип, имя и значение. Тип определяет, какого рода информацию может хранить переменная.\r\n\r\nПеред использованием любую переменную надо определить. Вначале идет тип переменной, потом ее имя. В качестве имени переменной может выступать любое произвольное название, которое удовлетворяет следующим требованиям:\r\n\r\nимя может содержать любые цифры, буквы и символ подчеркивания, при этом первый символ в имени должен быть буквой или символом подчеркивания\r\n\r\nв имени не должно быть знаков пунктуации и пробелов\r\n\r\nимя не может быть ключевым словом языка C#. Таких слов не так много, и при работе в Visual Studio среда разработки подсвечивает ключевые слова синим цветом.\r\n\r\nХотя имя переменой может быть любым, но следует давать переменным описательные имена, которые будут говорить об их предназначении.", "Переменные" },
                    { 8, 2, "Следующие операторы выполняют арифметические операции с операндами числовых типов:\r\n\r\nунарные — ++ (приращение), -- (уменьшение), + (плюс) и - (минус);\r\nбинарные — * (умножение), / (деление), % (остаток от деления), + (сложение) и - (вычитание).\r\nЭти операторы поддерживаются всеми целочисленными типами и типами с плавающей запятой.\r\n\r\nВ случае целочисленных типов эти операторы (за исключением операторов ++ и --) определяются для типов int, uint, longи ulong. Если операнды принадлежат к другим целочисленным типам (sbyte, byte, short, ushort или char), их значения преобразуются в тип int, который также является типом результата операции. Если операнды принадлежат к разным целочисленным типам или типам с плавающей запятой, их значения преобразуются в ближайший содержащий тип, если такой тип существует. Дополнительные сведения см. в разделе Числовые повышения уровня в статье Спецификации языка C#. Операторы ++ и -- определяются для всех целочисленных числовых типов и числовых типов с плавающей запятой, а также типа char. Тип результата выражения сложного назначения является типом левого операнда.", "Математические операции" },
                    { 9, 2, "", "Логические операции" },
                    { 10, 2, "", "Массивы" },
                    { 11, 2, "", "Функции" },
                    { 12, 2, "", "Объекты" },
                    { 13, 3, "Переменная в Java — это контейнер,  в котором может храниться некоторое значение данных для дальнейшего использования в программе. По сути переменная — это минимальная неделимая единица Java-приложения.\r\n\r\nПеременные в Java бывают двух видов: предназначенные для для маленьких данных (примитивные переменные) и для более сложных, тяжёлых (ссылочные переменные).\r\n\r\nСегодня мы рассмотрим первый случай, когда переменные хранят именно само значение данных. Такие переменные называют примитивными.", "Переменные" },
                    { 14, 3, "У оператора деления — своя специфика. Например, результатом выражения 10 / 3 будет тройка. Почему так? Когда оператор применяется к целым числам, остаток от деления отбрасывается, чтобы результатом тоже было целое число. Получить остаток от деления позволяет другой оператор — %. Например, остатком от деления 10 на 3 будет единица. Её и вернёт оператор %.\r\nМинус в Java тоже имеет двойной смысл: когда этот оператор применяют к двум операндам, минус называют бинарным. В этом случае речь идёт о вычитании. Например, 10 - 3 = 7. Когда же минус относится только к одному операнду, его называют унарным — он указывает, что значение операнда будет отрицательным: x = -1.\r\n\r\nБольшую часть математических операций в Java разработчики выполняют с помощью библиотек. Они содержат готовые функции для вычисления синусов, косинусов, возведения в степень и более сложных арифметических действий.", "Математические операции" },
                    { 15, 3, "", "Логические операции" },
                    { 16, 3, "", "Массивы" },
                    { 17, 3, "", "Функции" },
                    { 18, 3, "", "Объекты" },
                    { 19, 4, "Переменная — это область памяти компьютера, у которой есть имя. Структурно она состоит из трёх частей:\r\n\r\nИмя, или идентификатор, — это название, придуманное программистом, чтобы обращаться к переменной. В примерах выше это x, name и coin_flipping_result.\r\nЗначение — это информация, которая хранится в памяти компьютера и с которой работает программа. В примерах выше это 4, 'Виктория' и ['орёл', 'решка', 'решка', 'орёл']. Они всегда принадлежат к какому-либо типу данных.\r\nАдрес — это номер ячейки памяти, в которой хранится значение переменной.\r\nПриведём наглядную аналогию. Представьте большой производственный склад, заполненный стеллажами, на которых стоят коробки. Склад — это общая память компьютера. Допустим, на третьем стеллаже, на второй полке, в шестой ячейке стоит какая-нибудь коробка. Если в неё что-нибудь положить и наклеить этикетку с названием — коробка будет переменной. То, что в ней лежит, — это её значение. Третий стеллаж, вторая полка, пятая ячейка — её адрес, а этикетка — её имя.", "Переменные" },
                    { 20, 4, "Язык Python, благодаря наличию огромного количества библиотек для решения разного рода вычислительных задач, сегодня является конкурентом таким пакетам как Matlab и Octave. Запущенный в интерактивном режиме, он, фактически, превращается в мощный калькулятор. В этом уроке речь пойдет об арифметических операциях, доступных в данном языке.\r\n\r\nАрифметические операции будем изучать применительно к числам, причем работу с комплексными числами разберем отдельно. Также, кратко остановимся на битовых операциях, представлении чисел в разных системах исчисления и коснемся библиотеки math.\r\n\r\nКак было сказано в предыдущем уроке, посвященном типами и модели данных Python, в этом языке существует три встроенных числовых типа данных:\r\n\r\nцелые числа (int);\r\nвещественные числа (float);\r\nкомплексные числа (complex).\r\nЕсли в качестве операндов некоторого арифметического выражения используются только целые числа, то результат тоже будет целое число. Исключением является операция деления, результатом которой является вещественное число. При совместном использовании целочисленных и вещественных переменных, результат будет вещественным.", "Математические операции" },
                    { 21, 4, "", "Логические операции" },
                    { 22, 4, "", "Массивы" },
                    { 23, 4, "", "Функции" },
                    { 24, 4, "", "Объекты" },
                    { 25, 5, "В Ruby есть четыре типа переменных:\r\n\r\nЛокальные переменные. Определяются в методе или блоке и доступны только внутри этого метода или блока.\r\n\r\nInstance-переменные. Связаны с конкретным экземпляром класса и доступны из любого метода внутри этого экземпляра.\r\n\r\nClass-переменные. Связаны с конкретным классом и доступны для всех экземпляров этого класса.\r\n\r\nGlobal-переменные. Доступны из любого места в программе Ruby.\r\n\r\nДля объявления переменных используется строчная буква или подчеркивание, за которыми следует комбинация букв, цифр или подчеркиваний. Для присвоения значений переменным используется оператор присваивания (=).", "Переменные" },
                    { 26, 5, "Ruby поддерживает богатый набор операторов, как и следовало ожидать от современного языка. Большинство операторов — это фактически вызовы методов. Например, a + b интерпретируется как. + (B), где метод + в объекте, на который ссылается переменная a, вызывается с аргументом b .\r\n\r\nДля каждого оператора (+ — * /% ** & | ^ << >> && ||) существует соответствующая форма оператора сокращенного присваивания (+ = — = и т. д.).", "Математические операции" },
                    { 27, 5, "", "Логические операции" },
                    { 28, 5, "", "Массивы" },
                    { 29, 5, "", "Функции" },
                    { 30, 5, "", "Объекты" },
                    { 31, 6, "По умолчанию переменные присваиваются по значению. То есть, когда переменной присваивают выражение, значение оригинального выражения копируется в эту переменную. Это означает, например, что после присваивания одной переменной значения другой, изменение одной из переменных не влияет на другую. Дополнительную информацию об этом способе присваивания смотрите в разделе «Выражения».\r\n\r\nPHP также предлагает другой способ присваивания значений переменным: присваивание по ссылке. Это означает, что новая переменная просто ссылается (иначе говоря, «становится псевдонимом» или «указывает») на оригинальную переменную. Изменения в новой переменной отражаются на оригинале, и наоборот.\r\n\r\nДля присваивания по ссылке просто добавьте амперсанд & к началу имени присваиваемой (исходной) переменной. Например, следующий фрагмент кода дважды выводит «Меня зовут Боб»:", "Переменные" },
                    { 32, 6, "Предположим, что переменная A содержит 10, а переменная B содержит 20. Тогда приведенные ниже арифметические операторы выполняют следующие операции:\r\n\r\nоператор сложения (+) складывает два операнда (A + B; результат: 30);\r\nоператор вычитания (-) вычитает второй операнд из первого (A-B; результат: -10);\r\nоператор умножения (*) умножает один операнд на другой (A * B; результат: 200);\r\nоператор деления (/) делит делимое на делитель (B / A; результат: 2);\r\nоператор модуля (%) выводит остаток после целочисленного деления (B % A; результат: 0);\r\nоператор инкремента (++) увеличивает целочисленное значение на единицу (A++; результат: 11);\r\nоператор декремента (- -) уменьшает целочисленное значение на единицу (A- -; результат: 9).", "Математические операции" },
                    { 33, 6, "", "Логические операции" },
                    { 34, 6, "", "Массивы" },
                    { 35, 6, "", "Функции" },
                    { 36, 6, "", "Объекты" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Answer1", "Answer2", "Answer3", "Answer4", "CorrectAnswer", "CourseId", "Points", "Question" },
                values: new object[,]
                {
                    { 1, "", "", "", "", 0, 1, 0, "" },
                    { 2, "", "", "", "", 0, 1, 0, "" },
                    { 3, "", "", "", "", 0, 1, 0, "" },
                    { 4, "", "", "", "", 0, 1, 0, "" },
                    { 5, "", "", "", "", 0, 1, 0, "" },
                    { 6, "", "", "", "", 0, 1, 0, "" },
                    { 7, "", "", "", "", 0, 2, 0, "" },
                    { 8, "", "", "", "", 0, 2, 0, "" },
                    { 9, "", "", "", "", 0, 2, 0, "" },
                    { 10, "", "", "", "", 0, 2, 0, "" },
                    { 11, "", "", "", "", 0, 2, 0, "" },
                    { 12, "", "", "", "", 0, 2, 0, "" },
                    { 13, "", "", "", "", 0, 3, 0, "" },
                    { 14, "", "", "", "", 0, 3, 0, "" },
                    { 15, "", "", "", "", 0, 3, 0, "" },
                    { 16, "", "", "", "", 0, 3, 0, "" },
                    { 17, "", "", "", "", 0, 3, 0, "" },
                    { 18, "", "", "", "", 0, 3, 0, "" },
                    { 19, "", "", "", "", 0, 4, 0, "" },
                    { 20, "", "", "", "", 0, 4, 0, "" },
                    { 21, "", "", "", "", 0, 4, 0, "" },
                    { 22, "", "", "", "", 0, 4, 0, "" },
                    { 23, "", "", "", "", 0, 4, 0, "" },
                    { 24, "", "", "", "", 0, 4, 0, "" },
                    { 25, "", "", "", "", 0, 5, 0, "" },
                    { 26, "", "", "", "", 0, 5, 0, "" },
                    { 27, "", "", "", "", 0, 5, 0, "" },
                    { 28, "", "", "", "", 0, 5, 0, "" },
                    { 29, "", "", "", "", 0, 5, 0, "" },
                    { 30, "", "", "", "", 0, 5, 0, "" },
                    { 31, "", "", "", "", 0, 6, 0, "" },
                    { 32, "", "", "", "", 0, 6, 0, "" },
                    { 33, "", "", "", "", 0, 6, 0, "" },
                    { 34, "", "", "", "", 0, 6, 0, "" },
                    { 35, "", "", "", "", 0, 6, 0, "" },
                    { 36, "", "", "", "", 0, 6, 0, "" }
                });

            migrationBuilder.InsertData(
                table: "Docs",
                columns: new[] { "Id", "CourseId", "DocName", "LessonId" },
                values: new object[,]
                {
                    { 1, 1, "", 1 },
                    { 2, 1, "", 2 },
                    { 3, 1, "", 3 },
                    { 4, 1, "", 4 },
                    { 5, 1, "", 5 },
                    { 6, 1, "", 6 },
                    { 7, 2, "", 7 },
                    { 8, 2, "", 8 },
                    { 9, 2, "", 9 },
                    { 10, 2, "", 10 },
                    { 11, 2, "", 11 },
                    { 12, 2, "", 12 },
                    { 13, 3, "", 13 },
                    { 14, 3, "", 14 },
                    { 15, 3, "", 15 },
                    { 16, 3, "", 16 },
                    { 17, 3, "", 17 },
                    { 18, 3, "", 18 },
                    { 19, 4, "", 19 },
                    { 20, 4, "", 20 },
                    { 21, 4, "", 21 },
                    { 22, 4, "", 22 },
                    { 23, 4, "", 23 },
                    { 24, 4, "", 24 },
                    { 25, 5, "", 25 },
                    { 26, 5, "", 26 },
                    { 27, 5, "", 27 },
                    { 28, 5, "", 28 },
                    { 29, 5, "", 29 },
                    { 30, 5, "", 30 },
                    { 31, 6, "", 31 },
                    { 32, 6, "", 32 },
                    { 33, 6, "", 33 },
                    { 34, 6, "", 34 },
                    { 35, 6, "", 35 },
                    { 36, 6, "", 36 }
                });

            migrationBuilder.InsertData(
                table: "Homeworks",
                columns: new[] { "Id", "Content", "CourseId", "Deadline", "LessonId", "Title" },
                values: new object[,]
                {
                    { 1, "", 1, new DateOnly(2024, 6, 15), 1, "Домашнее задание" },
                    { 2, "", 1, new DateOnly(2024, 6, 15), 2, "Домашнее задание" },
                    { 3, "", 1, new DateOnly(2024, 6, 15), 3, "Домашнее задание" },
                    { 4, "", 1, new DateOnly(2024, 6, 15), 4, "Домашнее задание" },
                    { 5, "", 1, new DateOnly(2024, 6, 15), 5, "Домашнее задание" },
                    { 6, "", 1, new DateOnly(2024, 6, 15), 6, "Домашнее задание" },
                    { 7, "", 2, new DateOnly(2024, 6, 15), 7, "Домашнее задание" },
                    { 8, "", 2, new DateOnly(2024, 6, 15), 8, "Домашнее задание" },
                    { 9, "", 2, new DateOnly(2024, 6, 15), 9, "Домашнее задание" },
                    { 10, "", 2, new DateOnly(2024, 6, 15), 10, "Домашнее задание" },
                    { 11, "", 2, new DateOnly(2024, 6, 15), 11, "Домашнее задание" },
                    { 12, "", 2, new DateOnly(2024, 6, 15), 12, "Домашнее задание" },
                    { 13, "", 3, new DateOnly(2024, 6, 15), 13, "Домашнее задание" },
                    { 14, "", 3, new DateOnly(2024, 6, 15), 14, "Домашнее задание" },
                    { 15, "", 3, new DateOnly(2024, 6, 15), 15, "Домашнее задание" },
                    { 16, "", 3, new DateOnly(2024, 6, 15), 16, "Домашнее задание" },
                    { 17, "", 3, new DateOnly(2024, 6, 15), 17, "Домашнее задание" },
                    { 18, "", 3, new DateOnly(2024, 6, 15), 18, "Домашнее задание" },
                    { 19, "", 4, new DateOnly(2024, 6, 15), 19, "Домашнее задание" },
                    { 20, "", 4, new DateOnly(2024, 6, 15), 20, "Домашнее задание" },
                    { 21, "", 4, new DateOnly(2024, 6, 15), 21, "Домашнее задание" },
                    { 22, "", 4, new DateOnly(2024, 6, 15), 22, "Домашнее задание" },
                    { 23, "", 4, new DateOnly(2024, 6, 15), 23, "Домашнее задание" },
                    { 24, "", 4, new DateOnly(2024, 6, 15), 24, "Домашнее задание" },
                    { 25, "", 5, new DateOnly(2024, 6, 15), 25, "Домашнее задание" },
                    { 26, "", 5, new DateOnly(2024, 6, 15), 26, "Домашнее задание" },
                    { 27, "", 5, new DateOnly(2024, 6, 15), 27, "Домашнее задание" },
                    { 28, "", 5, new DateOnly(2024, 6, 15), 28, "Домашнее задание" },
                    { 29, "", 5, new DateOnly(2024, 6, 15), 29, "Домашнее задание" },
                    { 30, "", 5, new DateOnly(2024, 6, 15), 30, "Домашнее задание" },
                    { 31, "", 6, new DateOnly(2024, 6, 15), 31, "Домашнее задание" },
                    { 32, "", 6, new DateOnly(2024, 6, 15), 32, "Домашнее задание" },
                    { 33, "", 6, new DateOnly(2024, 6, 15), 33, "Домашнее задание" },
                    { 34, "", 6, new DateOnly(2024, 6, 15), 34, "Домашнее задание" },
                    { 35, "", 6, new DateOnly(2024, 6, 15), 35, "Домашнее задание" },
                    { 36, "", 6, new DateOnly(2024, 6, 15), 36, "Домашнее задание" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CourseId", "LessonId", "VideoName" },
                values: new object[,]
                {
                    { 1, 1, 1, "" },
                    { 2, 1, 2, "" },
                    { 3, 1, 3, "" },
                    { 4, 1, 4, "" },
                    { 5, 1, 5, "" },
                    { 6, 1, 6, "" },
                    { 7, 2, 7, "" },
                    { 8, 2, 8, "" },
                    { 9, 2, 9, "" },
                    { 10, 2, 10, "" },
                    { 11, 2, 11, "" },
                    { 12, 2, 12, "" },
                    { 13, 3, 13, "" },
                    { 14, 3, 14, "" },
                    { 15, 3, 15, "" },
                    { 16, 3, 16, "" },
                    { 17, 3, 17, "" },
                    { 18, 3, 18, "" },
                    { 19, 4, 19, "" },
                    { 20, 4, 20, "" },
                    { 21, 4, 21, "" },
                    { 22, 4, 22, "" },
                    { 23, 4, 23, "" },
                    { 24, 4, 24, "" },
                    { 25, 5, 25, "" },
                    { 26, 5, 26, "" },
                    { 27, 5, 27, "" },
                    { 28, 5, 28, "" },
                    { 29, 5, 29, "" },
                    { 30, 5, 30, "" },
                    { 31, 6, 31, "" },
                    { 32, 6, 32, "" },
                    { 33, 6, 33, "" },
                    { 34, 6, 34, "" },
                    { 35, 6, 35, "" },
                    { 36, 6, 36, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docs_CourseId",
                table: "Docs",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Docs_LessonId",
                table: "Docs",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_CourseId",
                table: "Homeworks",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_LessonId",
                table: "Homeworks",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CourseId",
                table: "Materials",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_HomeworkId",
                table: "Materials",
                column: "HomeworkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_LessonId",
                table: "Materials",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CourseId",
                table: "Tests",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CourseId",
                table: "Videos",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_LessonId",
                table: "Videos",
                column: "LessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Docs");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Homeworks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
