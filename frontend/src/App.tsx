import React from 'react';
import './App.css';
import Header from './Header';
import BowlerList from './BowlingCrew/BowlersList';

//It is returning the requirements Headers and Bowler list
function App() {
  return (
    <div className="App">
      <Header title="Bowling Crewww" />
      <BowlerList />
    </div>
  );
}

export default App;
