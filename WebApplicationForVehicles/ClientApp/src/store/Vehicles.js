const requestVehiclesType = 'REQUEST_VEHICLES';
const receiveVehiclesType = 'RECEIVE_VEHICLES';
const initialState = { vehicles: [], isLoading: false };

export const actionCreators = {
  requestVehicles: startDateIndex => async (dispatch, getState) => {    
    if (startDateIndex === getState().vehicles.startDateIndex) {
      // Don't issue a duplicate request (we already have or are loading the requested data)
      return;
    }

    dispatch({ type: requestVehiclesType, startDateIndex });

    const url = `api/SampleData/Vehicles?startDateIndex=${startDateIndex}`;
    const response = await fetch(url);
        const vehiclesPage = await response.json();

    dispatch({ type: receiveVehiclesType, startDateIndex, vehiclesPage });
  }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestVehiclesType) {
    return {
      ...state,
      startDateIndex: action.startDateIndex,
      isLoading: true
    };
  }

    if (action.type === receiveVehiclesType) {
        console.log('action.vehiclesPage', action.vehiclesPage)
    return {
      ...state,
        startDateIndex: action.startDateIndex,
        vehicles: action.vehiclesPage,
      isLoading: false
    };
  }

  return state;
};
