import React from 'react';

export function FetchTest() {
    async function fetchStuff(apiPath) {
        try {
          const response = await fetch(apiPath, {
            headers: {
              'Accept': 'application/json',
            },
          });
    
          if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
          }
    
          const data = await response.json();
          alert("Got something from Tasks:\n" + JSON.stringify(data));
        } catch (error) {
          console.error("Error fetching data:", error.message);
        }
      }

  return (
    <div>
      <h2>Fetch Test</h2>
      <button onClick={() => fetchStuff("userdata")}>Fetch Data from userdata</button>
      <button onClick={() => fetchStuff("calculation")}>Fetch Data from Calculations</button>
      <button onClick={() => fetchStuff("task")}>Fetch Data from Task</button>
      <button onClick={() => fetchStuff("test")}>Fetch Data from test</button>
      <button onClick={() => fetchStuff("login")}>Fetch Data from Login</button>


    </div>
  );
}
