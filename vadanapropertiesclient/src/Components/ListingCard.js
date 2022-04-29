import React from "react";
import { CardImg } from 'reactstrap';
import PropTypes from 'prop-types';

export default function ListingCard({ card }) {
    <div>
        <div className="card" style={{ width: '18rem', margin: '10px' }}>
            <CardImg
                alt="Card image"
                src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRdiL8kK1woke8HDhehvrrgLGbhB472Hw0dYQ&usqp=CAU'
            />
            <div className="card-body">
                <h6 className="card-title">Address: {card.Address}</h6>
                <hr />
                <p className="card-text">SquareFoot: {card.SquareFoot}</p>
                <p className="card-text">Rent: {card.Rent}</p>
                <p className="card-text">Details: {card.Details}</p>
                <p className="card-text">YearBuilt: {card.YearBuilt}</p>
                <p className="card-text">City: {card.City}</p>
                <p className="card-text">ImgUrl: {card.ImgUrl}</p>
                <label>
                    <input
                        type="checkbox"
                        checked={card.favorite ? 'checked' : ''}
                        onChange={handleChange}
                    />
                    Like this Car?
                </label>
                <div className="d-grid gap-2 mt-3">
                    <button
                        onClick={() => handleClick('delete')}
                        className="btn btn-danger"
                        type="button"
                    >
                        DELETE
                    </button>
                </div>
            </div>
        </div>
    </div>
  );
}
ListingsCard.propTypes = {
    card: PropTypes.shape(PropTypes.obj),
};