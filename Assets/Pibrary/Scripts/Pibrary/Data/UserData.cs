using System.Collections.Generic;
using Firebase.Firestore;

namespace Pibrary.Data
{
    public readonly struct UserData
    {
        public readonly List<DocumentReference> accessibleAuthorRef;
        public readonly List<DocumentReference> purchasedContentsRef;
    }
}