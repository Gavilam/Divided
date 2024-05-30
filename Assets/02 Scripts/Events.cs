using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Events
{
    public static UnityEvent ChangeCharacter = new UnityEvent();
    public static UnityEvent TurnOnTheLights = new UnityEvent();
    public static ChangeItemStateEvent ChangeItem = new ChangeItemStateEvent();
    public static ReadItemStateEvent ReadItem = new ReadItemStateEvent();
}

public class ChangeItemStateEvent : UnityEvent<Enums.Items>{}
public class ReadItemStateEvent : UnityEvent<Enums.Items> {}