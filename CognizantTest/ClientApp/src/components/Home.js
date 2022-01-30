import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, world!</h1>
        <p>Welcome to my test example!</p>
        <p>Load the dataset if it needs!</p>
      </div>
    );
  }
}
