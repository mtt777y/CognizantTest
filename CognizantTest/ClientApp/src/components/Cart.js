import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class Cart extends Component {
    static data = []; //data about cars
    static defCart; //default shopping Cart

    static increaseInfo(newData) {
        Cart.data.push(newData); //add new data cars
        Cart.defCart.setState({ data: Cart.data, count: 1 + Cart.defCart.state.count, total: Cart.defCart.state.total + newData.price  }); 
    }

    constructor(props) {
        super(props);
        this.state = { data: '', count: 0, total: 0 };
        Cart.defCart = this;
    }

    render() {
        let contains = this.state.count == 0
            ? 'empty'
            : this.state.data.map(dataSet => <p>{dataSet.brand + ' ' + dataSet.model}</p>);
            

    return (
        <div>
            <p>Cart: {this.state.count} cars for {this.state.total} usd</p>
            {contains}
        </div>
    );
  }
}
