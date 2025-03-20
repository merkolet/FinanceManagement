# FinanceManagement

# Общая идея решения
Разработанная система предназначена для управления финансами, включая учет банковских операций, анализ доходов и расходов, а также экспорт данных в различные форматы. В системе реализованы следующие функции:

1) Создание и управление финансовыми операциями (добавление операций с указанием суммы, категории и даты).
2) Анализ финансовых данных (расчет чистого дохода за период).
3) Использование паттерна Command для добавления операций с возможностью декорирования.
4) Экспорт данных в формате CSV, JSON и YAML через паттерн Visitor.
5) Использование DI-контейнера (Dependency Injection) для гибкости и расширяемости системы.

# Принципы SOLID и GRASP
SOLID

1) Single Responsibility Principle (SRP) – каждая сущность выполняет только одну задачу:
    FinanceAnalytics – только анализирует данные.
    CsvExportVisitor, JsonExportVisitor, YamlExportVisitor – только экспортируют данные.
    AddOperationCommand, TimedCommandDecorator – работают исключительно с командами.
   
3) Open/Closed Principle (OCP) – система поддерживает добавление новых форматов экспорта без изменения существующего кода. Новые экспортеры можно добавлять, реализуя IExportVisitor.

4) Liskov Substitution Principle (LSP) – CsvExportVisitor, JsonExportVisitor, YamlExportVisitor являются заменяемыми реализациями IExportVisitor, сохраняя интерфейс.

5) Interface Segregation Principle (ISP) – интерфейсы IExportVisitor и ICommand не содержат лишних методов, каждая реализация использует только нужный функционал.

6) Dependency Inversion Principl (DI) – зависимости передаются через DI-контейнер (ServiceCollection), а не создаются жестко внутри классов.


GRASP

1) Information Expert – ответственность за анализ финансовых данных отдана FinanceAnalytics.
2) Controller – FinanceFacade управляет процессами системы.
3) Low Coupling – модули экспорта, аналитики и команд слабо связаны и могут быть заменены.
4) High Cohesion – каждая сущность сфокусирована на одной задаче, нет перегруженных классов.


# Паттерны GoF

1) Command – реализован в AddOperationCommand, который инкапсулирует создание операций. TimedCommandDecorator добавляет дополнительную функциональность (измерение времени выполнения).
2) Decorator – TimedCommandDecorator расширяет команды, не меняя их исходную реализацию.
3) Visitor – CsvExportVisitor, JsonExportVisitor, YamlExportVisitor реализуют экспорт данных, а Operation принимает экспортёра.
4) Singleton – DI-контейнер создает единственный экземпляр FinanceFacade, что предотвращает дублирование состояния системы.
5) Facade – FinanceFacade объединяет в себе управление операциями, аналитикой и экспортом, предоставляя простой интерфейс для работы с системой. Это снижает сложность кода и облегчает поддержку.
6) Fabric - все доменные объекты создаются в FinanceFactory.
