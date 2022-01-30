import React, { Component } from 'react';
import { VehicleObj } from './VehicleObj';

export class VehicleData extends Component {
  static displayName = VehicleData.name;
    availableFilter;

  constructor(props) {
      super(props);
      this.state = { vehicleData: [], loading: true };
      this.availableFilter = false;
  }

  componentDidMount() {
      this.populateVehicleData();
  }


    onClickHandle() {
        this.setState({loading: true });
        this.availableFilter = true;
        this.populateVehicleData();
    }

  static renderVehicleDataTable(vehicles) {
        return (
                <div>
                    {vehicles.map(vehicle => <VehicleObj data={vehicle} />)}
                </div>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : VehicleData.renderVehicleDataTable(this.state.vehicleData);

    return (
      <div>
            <h1 id="tabelLabel" >Vehicle Data</h1>
            <p><button onClick={(e) => this.onClickHandle()}>Only available cars</button></p>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

    async populateVehicleData() {
        let response;
        if (this.availableFilter) {
            response = await fetch('api/vehicle/details?lic=true');
        }
        else {
            response = await fetch('api/vehicle');
        }
    
    const data = await response.json();
    this.setState({ vehicleData: data, loading: false });
    }
}
