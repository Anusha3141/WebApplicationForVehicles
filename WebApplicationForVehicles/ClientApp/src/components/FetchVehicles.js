import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/Vehicles';

class FetchVehicles extends Component {
  componentWillMount() {
    // This method runs when the component is first added to the page
    const startDateIndex = parseInt(this.props.match.params.startDateIndex, 10) || 0;
    this.props.requestVehicles(startDateIndex);
  }

  componentWillReceiveProps(nextProps) {
    // This method runs when incoming props (e.g., route params) change
    const startDateIndex = parseInt(nextProps.match.params.startDateIndex, 10) || 0;
    this.props.requestVehicles(startDateIndex);
  }

  render() {
    return (
      <div>
        <h1>Vehicles</h1>
        <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
            {console.log('fgh', this.props)}
            {renderVehiclesTable(this.props)}
        {renderPagination(this.props)}
      </div>
    );
  }
}

function renderVehiclesTable(props) {
  return (
    <table className='table'>
      <thead>
        <tr>
          <th>Id</th>
          <th>Make</th>
          <th>Model</th>
          <th>Year</th>
        </tr>
      </thead>
      <tbody>
              {props.vehicles.map(vehicle =>
                  <tr key={vehicle.id}>
                      <td>{vehicle.id}</td>
                      <td>{vehicle.make}</td>
                      <td>{vehicle.model}</td>
                      <td>{vehicle.year}</td>
          </tr>
        )}
      </tbody>
    </table>
  );
}

function renderPagination(props) {
  const prevStartDateIndex = (props.startDateIndex || 0) - 5;
  const nextStartDateIndex = (props.startDateIndex || 0) + 5;

  return <p className='clearfix text-center'>
    <Link className='btn btn-default pull-left' to={`/fetchvehicles/${prevStartDateIndex}`}>Previous</Link>
    <Link className='btn btn-default pull-right' to={`/fetchvehicles/${nextStartDateIndex}`}>Next</Link>
    {props.isLoading ? <span>Loading...</span> : []}
  </p>;
}

export default connect(
    state => state.Vehicles,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(FetchVehicles);
