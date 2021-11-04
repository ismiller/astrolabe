# Astrolabe

**Astrolabe** - это небольшая библиотека, позволяющая упростить навигацию между страницами в приложениях для платформы UWP (Universal Windows Platform), с внедрением зависимостей через IoC-контейнер.


## v1.0.0 
 * Реализовано построение маршрутов по схеме `тип модели представления - тип представления`
 * Реализовано построение графа зависимости на основе IoC-контейнера
 * Реализована установка контекста навигации
 * Реализована работа со стеком навигации
 * Реализована обработка событий навигации, загрузки и выгрузки в модели представления
 * Реализована передача данных между моделями представления при навигации

## Quick start

Установка пакета:  
`Install-Package IsMiller.AstrolabeNavigator -Version 1.0.0`

Все страницы представлений должны быть унаследованы от класса `AstrolabePage`:
````csharp
    public sealed partial class OtherPage : AstrolabePage 
    {

    }
````

Все классы моделей представления, используемые в навигации, должны реализовывать интерфейс `INavigatable` И принимать в конструкторе аргумент типа `IAstrolabe` - сервис навигации:
````csharp
    public class OtherPageViewModel : INavigatable
    {
        private readonly IAstrolabe _navigator;

        public OtherPageViewModel(IAstrolabe navigator)
        {
            _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
        }

        public void Leave() { /* Ваша реализация */ }

        public void Left() { /* Ваша реализация */ }

        public void Prepare(INavigationArgs args) { /* Ваша реализация */ }

        public void ViewCreated() { /* Ваша реализация */ }

        public void ViewLoaded() { /* Ваша реализация */ } 

        public void ViewLoading() { /* Ваша реализация */ }

        public void ViewUnloaded(){ /* Ваша реализация */ }
    }
````

Конфигурация сервиса строится следующим образом:
````csharp
    ...
    // Получаем экземпляр билдера сервиса навигации
    INavigatorBuilder builder = NavigatorBuilder.GetBuilder();

    // Создаем коллекцию сервисов и регистрируем все необходимые зависимости,
    // включая модели представления. 
    IServiceCollection collection = new ServiceCollection();
    collection.AddTransient<StartViewModel>();
    collection.AddTransient<OtherPageViewModel>();

    // Устанавливаем коллекцию сревисов в билдер
    builder.SetServiceCollection(collection);

    // Регистрируем в билдере маршруты по схеме "тип модели представления - тип представления"  
    builder.RegisterRoutes(rs =>
    {
        rs.RegisterScheme<StartViewModel, StartView>();
        rs.RegisterScheme<OtherPageViewModel, OtherPage>();
    });

    // Устанавливаем контекст навигации, передавай в параметры метода нужный Frame
    builder.SetNavigateContext(rootFrame);

    // Вызываем метод конфигурации сервиса навигации
    _navigator = builder.Build();

    // Выполняем навигацию на стартовую страницу. 
    _navigator.NavigateTo<OtherPageViewModel>(default);
````

Так же необходимо реализовать интерфейс `INavigationArgs` для возможности передачи аргументов из модели представления в модель представления при навигации.
И тогда вызов метода навигации с передачей аргумента будет выглядеть следующим образом:

````csharp

    var arg = new YourImplementation() {
        NavigationData = "Hello world"
    };

    _navigator.NavigateTo<OtherPageViewModel>(arg);
    
````

У принимающей модели представления обработка аргумента навигации может выглядеть следующим образом:
````csharp

    public void Prepare(INavigationArgs args)
    {
        if (args != null)
        {
            if (args.NavigationData is string message)
            {
                ReceivedMessage = $"Message: \"{message}\"";
            }
        }
    }
    
````