import React, { useEffect, useState } from 'react';
import axios from 'axios';

function InventoryReport() {
  const [report, setReport] = useState([]);

  useEffect(() => {
    axios.get('/api/Inventory/report')
      .then(res => setReport(res.data))
      .catch(err => console.error(err));
  }, []);

  return (
    <div className="container mt-5">
      <h3>Inventory Report</h3>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Name</th>
            <th>Type</th>
            <th>Size</th>
            <th>Material</th>
            <th>Available</th>
          </tr>
        </thead>
        <tbody>
          {report.map((p, idx) => (
            <tr key={idx} style={{ color: p.available < 50 ? 'red' : 'black' }}>
              <td>{p.name}</td>
              <td>{p.type}</td>
              <td>{p.size}</td>
              <td>{p.material}</td>
              <td>{p.available}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default InventoryReport;
