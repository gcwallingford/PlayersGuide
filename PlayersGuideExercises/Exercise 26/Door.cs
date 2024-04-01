namespace Exercise_26;

public class Door(State state, int passcode)
{
    private State _state = state;
    private int _passcode = passcode;

    public void Menu()
    {
        Console.WriteLine("The door is currently " + state);
        Console.WriteLine("What would you like to do with the door?");
        Console.WriteLine("1) Open");
        Console.WriteLine("2) Close");
        Console.WriteLine("3) Lock");
        Console.WriteLine("4) Unlock");
        switch (Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
                Open();
                break;
            case 2:
                Close();
                break;
            case 3:
                Lock();
                break;
            case 4:
                Close();
                break;
        }
    }

    public bool PasscodeCheck()
    {
        bool passcodeMatch = false;
        int passcodeInput;
        do
        {
            Console.WriteLine("Enter the 6-Digit Passcode:");
            passcodeInput = Convert.ToInt32(Console.ReadLine());
        } while (passcodeInput != passcode);

        if (passcodeInput == passcode)
        {
            passcodeMatch = true;
        }
        Console.Clear();
        return passcodeMatch;
    }
    
    private void Open()
    {
        Console.Clear();
        if (state == State.Closed)
        {
            state = State.Open;
            Console.WriteLine("The door has been opened.");
        }
        else if (state == State.Locked)
        {
            Console.WriteLine("The door cannot be opened while locked.");
        }
        else
        {
            Console.WriteLine("The door is already open.");
        }
        Menu();
    }

    private void Close()
    {
        Console.Clear();
        if (state == State.Open)
        {
            state = State.Closed;
            Console.WriteLine("The door has been closed.");
        }
        else if (state == State.Locked)
        {
            bool passcodeMatch = PasscodeCheck();
            if (passcodeMatch)
            {
                state = State.Closed;
                Console.WriteLine("The door has been unlocked.");
            }
        }
        else
        {
            Console.WriteLine("The door is already closed.");
        }
        Menu();
    }

    private void Lock()
    {
        Console.Clear();
        if (state == State.Closed)
        {
            state = State.Locked;
            Console.WriteLine("The door is now locked.");
        }
        else if (state == State.Open)
        {
            Console.WriteLine("The door must be closed in order to be locked.");
        }
        else
        {
            Console.WriteLine("The door is already locked.");
        }
        Menu();
    }
}