﻿namespace Nefarius.Utilities.DotNetInstaller.Util;

internal static class HttpClientExtensions
{
    public static async Task DownloadAsync(this HttpClient client, string requestUri, Stream destination,
        IProgress<float> progress = null, CancellationToken cancellationToken = default)
    {
        // Get the http headers first to examine the content length
        using HttpResponseMessage response =
            await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        long? contentLength = response.Content.Headers.ContentLength;

        using Stream download = await response.Content.ReadAsStreamAsync();
        // Ignore progress reporting when no progress reporter was 
        // passed or when the content length is unknown
        if (progress == null || !contentLength.HasValue)
        {
            await download.CopyToAsync(destination);
            return;
        }

        // Convert absolute progress (bytes downloaded) into relative progress (0% - 100%)
        Progress<long> relativeProgress =
            new(totalBytes => progress.Report((float)totalBytes / contentLength.Value));
        // Use extension method to report progress while downloading
        await download.CopyToAsync(destination, 81920, relativeProgress, cancellationToken);
        progress.Report(1);
    }
}