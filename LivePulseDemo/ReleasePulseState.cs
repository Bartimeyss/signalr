namespace LivePulseDemo;

public sealed class ReleasePulseState
{
    private int confirmedReleases;

    public int ConfirmedReleases => Volatile.Read(ref confirmedReleases);

    public event Action? Changed;

    public void ConfirmRelease()
    {
        Interlocked.Increment(ref confirmedReleases);
        Changed?.Invoke();
    }
}
