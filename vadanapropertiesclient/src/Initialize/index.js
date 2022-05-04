import React, { useEffect, useState } from 'react';
import Routing from '../Routes';
import Navbar from '../Components/Navbar';
import auth from '../Data/ApiKeys';



function Initialize() {
    const [user, setUser] = useState(null);
    useEffect(() => {
        auth.onAuthStateChanged((authed) => {
          if (authed) {
            const userObj = {
              uid: authed.uid,
              fullName: authed.displayName,
              profilePic: authed.photoURL,
              username: authed.email.split('@')[0],
            };
            setUser(userObj);
            sessionStorage.setItem('idToken', authed.accessToken);
            // userExistsInDB(authed.accessToken);
          } else if (user || user === null) {
            setUser(false);
          }
        });
      }, []);
    
    return (
        <div>
            <Navbar />
            <Routing />
        </div>
    );
}

export default Initialize;