import React from 'react';
import expect from 'expect';
import { shallow } from 'enzyme';
import Instruction from '../js/pages/Instruction';
import Assumption from '../js/components/instruction/Assumption';
import Requirement from '../js/components/instruction/Requirement';
import OtherFeature from '../js/components/instruction/OtherFeature';

describe('Component: Instruction page', () => {
	it('renders 1 <Instruction /> component', () => {
		const wrapper = shallow(<Instruction/>);
		expect(wrapper.length).toEqual(1);
	});

	it('renders 1 <Assumption /> component', () => {
		const wrapper = shallow(<Instruction/>);
		expect(wrapper.find(Assumption).length).toEqual(1);
	});

	it('renders 1 <Requirement /> component', () => {
		const wrapper = shallow(<Instruction/>);
		expect(wrapper.find(Requirement).length).toEqual(1);
	});

});