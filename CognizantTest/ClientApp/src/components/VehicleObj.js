import React, { Component } from 'react';
import { Cart } from './Cart';
import { NavMenu } from './NavMenu';

export class VehicleObj extends Component {

    dateAdded;
    id;
    brand;
    model;
    price;
    warehouse;
    licensed;

    constructor(props) {
        super(props);
        this.state = { additional: false };
        this.dateAdded = props.data.dateAdded;
        this.brand = props.data.brand;
        this.model = props.data.model;
        this.price = props.data.price;
        this.warehouse = props.data.warehouse;
        this.licensed = props.data.licensed;
    }

    onClickHandle() {
        this.setState({ additional: !this.state.additional });
    }

    render() {
        let buyButton = this.licensed
            ? <button onClick={(e) => { Cart.increaseInfo(this) }}> Buy a car!</button >
            : <p><b>You can't buy this car! :(</b></p>;

        let additionalComment = this.state.additional
            ? <div><p>{this.warehouse}</p><p>{buyButton}</p></div>
            : '';

        return (
            <div>
                <table className='table table-striped'>
                <tr>
                    <td class="col-md-3">{this.brand}</td>
                    <td class="col-md-3">{this.model}</td>
                    <td class="col-md-4">{this.price}</td>
                        <td class="col-md-5">{this.dateAdded}</td>
                        <td class="col-md-2"><button onClick={(e) => this.onClickHandle()}>Know more!</button></td>
                </tr>
                </table>
                {additionalComment}
            </div>)
    }
}
