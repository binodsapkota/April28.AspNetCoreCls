// See https://aka.ms/new-console-template for more information
using GenricsAndCollections;

Console.WriteLine("Hello, World!");
Box box = new Box();
box.Data = 10;
int data = (int)box.Data;//casting is required

GenericBox<int> genericBox = new GenericBox<int>();
genericBox.Data = 10;
int data1 = genericBox.Data;


GenericBox<string> genericBoxStr = new GenericBox<string>();
genericBoxStr.Data = "Binod";
string strData = genericBoxStr.Data;


ListExample listExample = new ListExample();
StackExample stackExample = new StackExample();
QueueExample queueExample = new QueueExample();
DictionaryExample dictionaryExample = new DictionaryExample();
HashTableExample hashTableExample = new HashTableExample();
