import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import ProductList from './components/ProductList';
import InventoryReport from './components/InventoryReport';

function App() {
  return (
    <div className="container">
      <h1 className="my-4 text-center">Besmoke Inventory Tracker</h1>
      <ProductList />
      <InventoryReport />
    </div>
  );
}

export default App;
