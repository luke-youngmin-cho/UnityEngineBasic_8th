using Collections;

MyDynamicArray myDynamicArray = new MyDynamicArray();
myDynamicArray.Add(5);
myDynamicArray.Add(3);
myDynamicArray.Add(9);
myDynamicArray.Add(7);
int tmpIndex = myDynamicArray.FindIndex(7);
if (myDynamicArray.Remove(tmpIndex))
{
    Console.WriteLine($"{tmpIndex} index of myDynamicArray has removed");
}
myDynamicArray.RemoveAt(tmpIndex);

for (int i = 0; i < myDynamicArray.Count; i++)
{
    Console.WriteLine(myDynamicArray[i]);
}
