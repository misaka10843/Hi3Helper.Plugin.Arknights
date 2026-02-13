using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hi3Helper.Plugin.Arknights.Management.Api;

// ==========================================
// 请求结构
// ==========================================
public class ArknightsBatchRequest
{
    [JsonPropertyName("seq")] public string Seq { get; set; } = null!;

    [JsonPropertyName("proxy_reqs")] public List<ArknightsProxyRequest> ProxyReqs { get; set; } = new();
}

public class ArknightsProxyRequest
{
    [JsonPropertyName("kind")] public string Kind { get; set; } = null!;

    [JsonPropertyName("get_latest_game_req")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ArknightsGetLatestGameReq? GetLatestGameReq { get; set; }

    // 通用请求体用于 Banner, News, BgImage, Sidebar
    [JsonPropertyName("get_banner_req")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ArknightsCommonReq? GetBannerReq { get; set; }

    [JsonPropertyName("get_announcement_req")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ArknightsCommonReq? GetAnnouncementReq { get; set; }

    [JsonPropertyName("get_main_bg_image_req")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ArknightsCommonReq? GetMainBgImageReq { get; set; }

    [JsonPropertyName("get_sidebar_req")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ArknightsCommonReq? GetSidebarReq { get; set; }
}

public class ArknightsGetLatestGameReq
{
    [JsonPropertyName("appcode")] public string AppCode { get; set; } = null!;
    [JsonPropertyName("channel")] public string Channel { get; set; } = null!;
    [JsonPropertyName("sub_channel")] public string SubChannel { get; set; } = null!;
    [JsonPropertyName("version")] public string Version { get; set; } = null!;
    [JsonPropertyName("launcher_appcode")] public string LauncherAppCode { get; set; } = null!;
}

public class ArknightsCommonReq
{
    [JsonPropertyName("appcode")] public string AppCode { get; set; } = null!;
    [JsonPropertyName("language")] public string Language { get; set; } = "zh-cn";
    [JsonPropertyName("channel")] public string Channel { get; set; } = null!;
    [JsonPropertyName("sub_channel")] public string SubChannel { get; set; } = null!;
    [JsonPropertyName("platform")] public string Platform { get; set; } = "Windows";
    [JsonPropertyName("source")] public string Source { get; set; } = "launcher";
}

// ==========================================
// 响应结构
// ==========================================
public class ArknightsBatchResponse
{
    [JsonPropertyName("proxy_rsps")] public List<ArknightsProxyResponse>? ProxyRsps { get; set; }
}

public class ArknightsProxyResponse
{
    [JsonPropertyName("kind")] public string? Kind { get; set; }

    [JsonPropertyName("get_latest_game_rsp")]
    public ArknightsGetLatestGameRsp? GetLatestGameRsp { get; set; }

    [JsonPropertyName("get_banner_rsp")] public ArknightsGetBannerRsp? GetBannerRsp { get; set; }

    [JsonPropertyName("get_announcement_rsp")]
    public ArknightsGetAnnouncementRsp? GetAnnouncementRsp { get; set; }

    [JsonPropertyName("get_main_bg_image_rsp")]
    public ArknightsGetMainBgImageRsp? GetMainBgImageRsp { get; set; }

    [JsonPropertyName("get_sidebar_rsp")] public ArknightsGetSidebarRsp? GetSidebarRsp { get; set; }
}

// --- 版本信息 ---
public class ArknightsGetLatestGameRsp
{
    [JsonPropertyName("action")] public int Action { get; set; }
    [JsonPropertyName("version")] public string? Version { get; set; }
    [JsonPropertyName("pkg")] public ArknightsPkgInfo? Pkg { get; set; }
}

public class ArknightsPkgInfo
{
    [JsonPropertyName("packs")] public List<ArknightsPack>? Packs { get; set; }
    [JsonPropertyName("file_path")] public string? FilePath { get; set; }
}

public class ArknightsPack
{
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("md5")] public string? Md5 { get; set; }
    [JsonPropertyName("package_size")] public string? PackageSize { get; set; }
}

// --- Banner ---
public class ArknightsGetBannerRsp
{
    [JsonPropertyName("banners")] public List<ArknightsBanner>? Banners { get; set; }
}

public class ArknightsBanner
{
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("jump_url")] public string? JumpUrl { get; set; }
}

// --- 公告 ---
public class ArknightsGetAnnouncementRsp
{
    [JsonPropertyName("tabs")] public List<ArknightsAnnouncementTab>? Tabs { get; set; }
}

public class ArknightsAnnouncementTab
{
    [JsonPropertyName("tabName")] public string? TabName { get; set; }
    [JsonPropertyName("announcements")] public List<ArknightsAnnouncement>? Announcements { get; set; }
}

public class ArknightsAnnouncement
{
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonPropertyName("jump_url")] public string? JumpUrl { get; set; }
    [JsonPropertyName("start_ts")] public string? StartTs { get; set; } // 时间戳字符串
}

// --- 背景图 ---
public class ArknightsGetMainBgImageRsp
{
    [JsonPropertyName("main_bg_image")] public ArknightsBgImageInfo? MainBgImage { get; set; }
}

public class ArknightsBgImageInfo
{
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("video_url")] public string? VideoUrl { get; set; }
}

// --- Sidebar ---
public class ArknightsGetSidebarRsp
{
    [JsonPropertyName("sidebars")] public List<ArknightsSidebar>? Sidebars { get; set; }
}

public class ArknightsSidebar
{
    [JsonPropertyName("media")] public string? Media { get; set; }
    [JsonPropertyName("pic")] public ArknightsSidebarPic? Pic { get; set; }
    [JsonPropertyName("jump_url")] public string? JumpUrl { get; set; }
    [JsonPropertyName("sidebar_labels")] public List<ArknightsSidebarLabel>? SidebarLabels { get; set; }
}

public class ArknightsSidebarPic
{
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
}

public class ArknightsSidebarLabel
{
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonPropertyName("jump_url")] public string? JumpUrl { get; set; }
}