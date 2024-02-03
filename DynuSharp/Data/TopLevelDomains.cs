namespace DynuSharp.Data;
/// <summary>
/// Provides a set of top-level domains as constants and a read-only list of all top-level domains.
/// </summary>
public static class TopLevelDomains
{
    /// <summary>
    /// General use domain.
    /// </summary>
    public const string AccessCamOrg = "accesscam.org";

    /// <summary>
    /// General use domain.
    /// </summary>
    public const string CamDvrOrg = "camdvr.org";

    /// <summary>
    /// General use domain.
    /// </summary>
    public const string CasaCamNet = "casacam.net";

    /// <summary>
    /// General use domain.
    /// </summary>
    public const string DdnsFreeCom = "ddnsfree.com";

    /// <summary>
    /// General use domain.
    /// </summary>
    public const string DdnsGeekCom = "ddnsgeek.com";

    /// <summary>
    /// General use domain.
    /// </summary>
    public const string FreeDdnsOrg = "freeddns.org";

    /// <summary>
    /// General use domain.
    /// </summary>
    public const string GiizeCom = "giize.com";

    /// <summary>
    /// General use domain.
    /// </summary>
    public const string GleezeCom = "gleeze.com";

    /// <summary>
    /// General use domain.
    /// </summary>
    public const string KozowCom = "kozow.com";

    /// <summary>
    /// General use domain.
    /// </summary>
    public const string LoseYourIpCom = "loseyourip.com";

    /// <summary>
    /// General use domain.
    /// </summary>
    public const string MyWireOrg = "mywire.org";

    /// <summary>
    /// General use domain.
    /// </summary>
    public const string OoGuyCom = "ooguy.com";

    /// <summary>
    /// General use domain.
    /// </summary>
    public const string TheWorkPcCom = "theworkpc.com";

    /// <summary>
    /// General use domain.
    /// </summary>
    public const string WebRedirectOrg = "webredirect.org";

    /// <summary>
    /// Members only domain.
    /// </summary>
    public const string OneCoolDnsCom = "1cooldns.com";

    /// <summary>
    /// Members only domain.
    /// </summary>
    public const string FourCloudClick = "4cloud.click";

    /// <summary>
    /// Members only domain.
    /// </summary>
    public const string BumbleShrimpCom = "bumbleshrimp.com";

    /// <summary>
    /// Members only domain.
    /// </summary>
    public const string DynuDdnsCom = "dynuddns.com";

    /// <summary>
    /// Members only domain.
    /// </summary>
    public const string DynuDdnsNet = "dynuddns.net";

    /// <summary>
    /// Members only domain.
    /// </summary>
    public const string DdnsGuruCom = "ddnsguru.com";

    /// <summary>
    /// Members only domain.
    /// </summary>
    public const string MySynologyNet = "mysynology.net";

    /// <summary>
    /// A read-only list of all top-level domains.
    /// </summary>
    public static readonly IReadOnlyList<string> AllTopLevelDomains = new[]
    {
        AccessCamOrg,
        CamDvrOrg,
        CasaCamNet,
        DdnsFreeCom,
        DdnsGeekCom,
        FreeDdnsOrg,
        GiizeCom,
        GleezeCom,
        KozowCom,
        LoseYourIpCom,
        MyWireOrg,
        OoGuyCom,
        TheWorkPcCom,
        WebRedirectOrg,
        OneCoolDnsCom,
        FourCloudClick,
        BumbleShrimpCom,
        DynuDdnsCom,
        DynuDdnsNet,
        DdnsGuruCom,
        MySynologyNet
    };

    /// <summary>
    /// A read-only list of general use domains.
    /// </summary>
    public static readonly IReadOnlyList<string> GeneralUseDomains = new[]
    {
        AccessCamOrg,
        CamDvrOrg,
        CasaCamNet,
        DdnsFreeCom,
        DdnsGeekCom,
        FreeDdnsOrg,
        GiizeCom,
        GleezeCom,
        KozowCom,
        LoseYourIpCom,
        MyWireOrg,
        OoGuyCom,
        TheWorkPcCom,
        WebRedirectOrg
    };

    /// <summary>
    /// A read-only list of members only domains.
    /// </summary>
    public static readonly IReadOnlyList<string> MembersOnlyDomains = new[]
    {
        OneCoolDnsCom,
        FourCloudClick,
        BumbleShrimpCom,
        DynuDdnsCom,
        DynuDdnsNet,
        DdnsGuruCom,
        MySynologyNet
    };
}