namespace AFTT.EF.Enums;

public enum MissionUrgency
{
    Low = 1,       // Tasks that can be completed at a later time without significant impact
    Medium = 2,    // Tasks that should be addressed in a reasonable timeframe
    High = 3,      // Tasks that require immediate attention and action
    Critical = 4   // Tasks that must be addressed immediately to prevent severe consequences
}