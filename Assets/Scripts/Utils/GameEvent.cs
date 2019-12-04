namespace OOO.Utils
{
    public class GameEvent
    {
    }

    /** Fired when the GameTypeResolver has parsed the arguments. */
    public class GameTypeLoadedEvent : GameEvent
    {
    }

    /** Fired when player collects the key. */
    public class KeyCollectedEvent : GameEvent
    {
    }

    /** Fired when player (each of them) enters the exit area. */
    public class ExitOccupancyChangeEvent : GameEvent
    {
        public enum Type
        {
            ENTER,
            LEAVE
        }

        public Type type;
        public GameType playerType;
    }

    public class ExitOpenEvent : GameEvent
    {
    }
}