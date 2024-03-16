import { useEffect, useState } from 'react';
import { Bowler } from '../types/Bowler';

function BowlersList() {
  const [bowlerData, setBowlerData] = useState<Bowler[]>([]);

  //using this so that my fan stops going crazy
  useEffect(() => {
    const fetchBowlerData = async () => {
      const rsp = await fetch('http://localhost:5104/Bowling');
      const b = await rsp.json();
      setBowlerData(b);
    };

    fetchBowlerData();
  }, []);

  return (
    <>
      <div className="row">
        <h4 className="text-center ">Bowling Crew</h4>
      </div>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {bowlerData.map((b) => (
            <tr key={b.bowlerId}>
              <td>
                {b.bowlerFirstName} {b.bowlerMiddleInit} {b.bowlerLastName}
              </td>
              <td>{b.team.teamName}</td>
              <td>{b.bowlerAddress}</td>
              <td>{b.bowlerCity}</td>
              <td>{b.bowlerState}</td>
              <td>{b.bowlerZip}</td>
              <td>{b.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default BowlersList;
