// Change IBM Lotus Notes ID file.

// Instantiate Notes Session
public NotesSession session = null;
session = new Domino.NotesSessionClass();

string password = "";
string idFile = "C:\\Program Files (x86)\\IBM\Lotus\\Notes\\Data\\user.id"

// Attempt to initialize the session with the current ID file and password.
try
{
    // Initialize Notes Session    
    session.Initialize(password);
}
catch(Exception e)
{
    // Exception if ID file or password is wrong.
}

// Change ID File
try
{
    // Set the notes.ini file setting KeyFileName to point to the new ID file.
    session.SetEnvironmentVar("KeyFileName", idFile, true);
    // Set a recent date for CertificateExpChecked
    session.SetEnvironmentVar("CertificateExpChecked", idFile + " 12/31/2017", true);
    
    // Get KeyFileName value.
    string keyfilename = session.GetEnvironmentString("KeyFilename", true);
    
    // Nullify the NotesSession, saving the new ID file to the INI file.
    // Manually call garbage collection.
    session = null;
    GC.Collect();
    GC.WaitForPendingFinalizers();              

    // Instantiate Notes Session
    session = new Domino.NotesSessionClass();
    // Initialize Notes Session   
    session.Initialize(password);
}
catch(Exception e)
{
    // Exception if ID file or password is wrong.
}
