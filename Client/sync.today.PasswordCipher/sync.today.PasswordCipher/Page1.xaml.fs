namespace Views

open FsXaml
open System.Windows
open System.Windows.Controls
open sync.today.cipher

type Page1 = XAML<"Page1.xaml", true>
   
type Page1ViewController() = 
    inherit UserControlViewController<Page1>()

    let mutable myView : Page1 = null
    
    member this.cipherAndShow ( eventArgs : RoutedEventArgs ) =
        let  cipheredPassword = StringCipher.Encrypt(  myView.Password.Password, myView.LoginName.Text  )
        Clipboard.SetText( cipheredPassword )
        System.Windows.MessageBox.Show ( sprintf "Ciphered Password %A is in your clipboard, you can Paste it into an email" cipheredPassword ) |> ignore

    override this.OnLoaded view = 
        myView <- view
        view.Cipher_Button.Click.Subscribe this.cipherAndShow
        |> this.DisposeOnUnload