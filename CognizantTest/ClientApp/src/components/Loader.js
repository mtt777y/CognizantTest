import React, { Component } from 'react';

//data loader
export class Loader extends Component {
    static displayName = Loader.name;

  constructor(props) {
    super(props);
      this.state = {
          file: '',
          data: '',
          info: '', 
      };
  }

    _handleImageChange(e) {
        e.preventDefault();

        let reader = new FileReader();
        let file = e.target.files[0];

        reader.onloadend = () => {
            this.setState({
                file: file,
                data: reader.result
            });
        }

        reader.readAsDataURL(file)
    }

    async _handleLoadData() {

        if (this.state.data == '') {
            return;
        }

        const json = atob(this.state.data.substring(29)); //prepare data, and read it

        const requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify({ Data: json })
        };

        const response = await fetch('api/loader', requestOptions);
        const data = await response.json();
        if (response.status == 200) {
            this.setState({ info: 'Success!'});
            console.log('Good');
        }
        else {
            this.setState({info : 'Some error!'});
            console.log('Bad');
        }
    }

  render() {
    return (
      <div>
            <h1>Loader</h1>

            <p aria-live="polite">Load data here: </p>

            <form>
                <input className="fileInput" type="file" onChange={(e) => this._handleImageChange(e)}/>
            </form>


            <button onClick={(e) => this._handleLoadData()}>Load!</button>
            {this.state.info}
      </div>
    );
  }
}