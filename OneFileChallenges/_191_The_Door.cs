//191 The Card
Console.Title = "The Door";


Console.Write("To create new door name password: ");
string userPassword = Console.ReadLine();
Door createdDoor = new Door(userPassword);
while (true)
{
    Console.WriteLine($"Door is {createdDoor._doorState}.");
    ChangeDoorState();
}
void ChangeDoorState()
{
    Console.WriteLine("0 - Lock, 1 - Close, 2 - Open, 3 - Unlock, 4 - Change Password");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 0:
            createdDoor.LockDoor();
            break;
        case 1:
            createdDoor.CloseDoor();
            break;
        case 2:
            createdDoor.OpenDoor();
            break;
        case 3:
            Console.Write("Password? ");
            string password = Console.ReadLine();
            createdDoor.UnlockDoor(password);
            break;
        case 4:
            Console.Write("Current Password? ");
            string currentPassword = Console.ReadLine(); 
            Console.Write("New Password? ");
            string newPassword = Console.ReadLine();
            createdDoor.ChangePassword(newPassword, currentPassword);
            break;
        default:
            break;
    }
}

class Door
{
    public DoorState _doorState { get; private set; } = DoorState.Locked;
    private string _password;

    public Door(string password) => _password = password;
    public void ChangePassword(string newPassword, string currentPassword) => _password = (_password == currentPassword ? newPassword : _password);

    public void CloseDoor() => _doorState = (_doorState == DoorState.Opened ?  DoorState.Closed : _doorState);
    public void OpenDoor() => _doorState = (_doorState == DoorState.Closed ? DoorState.Opened : _doorState);
    public void LockDoor() => _doorState = (_doorState == DoorState.Closed ? DoorState.Locked : _doorState);
    public void UnlockDoor(string password) => _doorState = (_doorState == DoorState.Locked && _password == password ? DoorState.Closed : _doorState);

}

enum DoorState { Locked, Closed, Opened}