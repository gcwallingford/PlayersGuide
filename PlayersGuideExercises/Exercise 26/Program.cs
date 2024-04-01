using Exercise_26;

Door door = new(State.Closed, 123456);


if (door.PasscodeCheck())
{
    door.Menu();
}