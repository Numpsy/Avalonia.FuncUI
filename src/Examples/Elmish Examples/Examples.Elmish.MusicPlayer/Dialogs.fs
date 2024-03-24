namespace Examples.MusicPlayer


module Dialogs =
    open Avalonia
    open Avalonia.Platform.Storage

    let showMusicFilesDialog(provider: IStorageProvider, filters: FilePickerFileType List option) =

        let filters =
            match filters with
            | Some filter -> filter
            | None ->
                let patterns = [ "*.mp3"; "*.wav" ]
                let filter = FilePickerFileType("Music", Patterns = patterns)
                List.singleton filter

        let options = FilePickerOpenOptions(AllowMultiple = true, Title = "Select Your Music Files", FileTypeFilter = filters)

        task {
            let! musicFolder = provider.TryGetWellKnownFolderAsync Platform.Storage.WellKnownFolder.Music
            options.SuggestedStartLocation <- musicFolder

            return! provider.OpenFilePickerAsync options
        }

    let showMusicFolderDialog(provider: IStorageProvider) =
        task {
            let! musicFolder = provider.TryGetWellKnownFolderAsync Platform.Storage.WellKnownFolder.Music
            let options = FolderPickerOpenOptions(Title = "Choose where to look up for music", SuggestedStartLocation = musicFolder)

            return! provider.OpenFolderPickerAsync options
        }
