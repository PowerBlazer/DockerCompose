import React, { useEffect, useState } from 'react';

interface IUser{
  name:string
}
function App() {

  const [users,setUsers] = useState<IUser[]>([]);

  useEffect(()=>{
    fetchUsers();
  },[]);

  async function fetchUsers() {
      const response = await fetch('api/users',{method:"GET"});

      const responseJson = await response.json();

      setUsers(responseJson);
  }

  const usersElement = users.map((value,index)=> <li key={index}>{value.name}</li>);

  return (
    <div className="App">
      <ul>
        {usersElement}
      </ul>
    </div>
  );
}

export default App;
