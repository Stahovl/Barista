using UnityEngine;

[RequireComponent (typeof(PlayerView))]
[RequireComponent (typeof(PlayerStateMachine))]
[RequireComponent (typeof(InputHandler))]
public class Player : MonoBehaviour
{
    private PlayerModel _model;
    private PlayerViewModel _viewModel;
    private PlayerView _view;

    private void Start()
    {
        _model = new PlayerModel();
        _view = GetComponent<PlayerView>();
        _viewModel = new PlayerViewModel(_model, _view);
    }

    private void OnDestroy()
    {
        _viewModel.Dispose();
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _viewModel.UpdateMovementInput(input);
    }
}
